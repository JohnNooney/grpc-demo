using System.Security.Cryptography.X509Certificates;

public class CertHelper{
    private string pfxFilePath;
    private string pfxFile;
    private string password;


    public CertHelper()
    {
        pfxFilePath = Environment.GetEnvironmentVariable("CERT_PATH") ?? "";
        pfxFile = Environment.GetEnvironmentVariable("CERT_FILE") ?? "";
        password = Environment.GetEnvironmentVariable("CERT_PASS") ?? "";
    }

    public bool doesCertificateExist()
    {
        if(pfxFile == "" || password == "" || pfxFilePath == "")
        {
            Console.WriteLine("Certificate not specified. Proceeding with default configuration.");

            return false;
        }

        return true;
    }

    public X509Certificate createPfxCertificate()
    {
        return new X509Certificate2(Path.Combine(pfxFilePath, pfxFile), password);
    }
}