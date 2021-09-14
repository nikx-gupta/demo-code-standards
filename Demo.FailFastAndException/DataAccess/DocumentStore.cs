using System.Reflection.Metadata;
using Demo.FailFastAndException.Models;

namespace Demo.FailFastAndException.DataAccess
{
    public class DocumentStore
    {
        public DocumentInfo GetDocumentForEmployee(int employeeId)
        {
            if (employeeId == 1)
                return new DocumentInfo();

            return null;
        }

        public void UploadDocument(int employeeId, DocumentInfo metadata)
        {
            
        }
    }
}