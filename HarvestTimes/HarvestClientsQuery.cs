using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace HarvestTimes
{
	public class HarvestClientsQuery
	{
		private readonly HarvestUserSettings _harvestUserSettings;

		private static bool Validator(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
		{
			return true;
		}

		public HarvestClientsQuery(HarvestUserSettings harvestUserSettings)
		{
			_harvestUserSettings = harvestUserSettings;
		}

		public string GetData(string url)
		{
			HttpWebResponse response = null;

			string uri = url;
			string username = _harvestUserSettings.Username;
			string password = _harvestUserSettings.Password;
			string usernamePassword = username + ":" + password;

			ServicePointManager.ServerCertificateValidationCallback = Validator;

			try
			{
				var request = WebRequest.Create(uri) as HttpWebRequest;
				request.MaximumAutomaticRedirections = 1;
				request.AllowAutoRedirect = true;
				request.Accept = "application/xml";
				request.ContentType = "application/xml";
				request.UserAgent = "HarvestTimes";
				request.Headers.Add("Authorization", "Basic " + Convert.ToBase64String(new ASCIIEncoding().GetBytes(usernamePassword)));

				using (response = request.GetResponse() as HttpWebResponse)
				{
					if (request.HaveResponse && response != null)
					{
						var reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
						var sbSource = new StringBuilder(reader.ReadToEnd());
						return sbSource.ToString();
					}
				}
			}
			catch (WebException wex)
			{
				if (wex.Response != null)
				{
					using (var errorResponse = (HttpWebResponse)wex.Response)
					{
						Debug.WriteLine(
							"The server returned '{0}' with the status code {1} ({2:d}).",
							errorResponse.StatusDescription, errorResponse.StatusCode,
							errorResponse.StatusCode);
					}
				}
				else
				{
					Debug.WriteLine(wex);

				}
			}
			finally
			{
				if (response != null) { response.Close(); }
			}
			return string.Empty;
		}
	}
}