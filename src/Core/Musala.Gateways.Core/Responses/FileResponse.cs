namespace Musala.Gateways.Core.Responses
{
    public class FileResponse
    {
        public byte[] File{get; set;}
        public string Type{get; set;}
        public string Name { get; set; }
        public int Size { get; set; }
        
    }
}