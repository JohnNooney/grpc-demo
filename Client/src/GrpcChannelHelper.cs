using Grpc.Net.Client;
using Client;

public class GrpcChannelHelper{
    private HttpClientHandler handler;
    private CertHelper certHelper;

    public GrpcChannelHelper()
    {
        handler = new HttpClientHandler();
        certHelper = new CertHelper();
        
        if(certHelper.doesCertificateExist())
        {
            var clientCertificate = certHelper.createPfxCertificate();
            handler.ClientCertificates.Add(clientCertificate);
        }
    }

    public HttpClientHandler GetHttpClientHandler()
    {
        return handler;
    }
}