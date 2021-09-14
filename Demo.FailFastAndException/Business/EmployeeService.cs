using Demo.FailFastAndException.DataAccess;
using Demo.FailFastAndException.Exceptions;
using Demo.FailFastAndException.Models;

namespace Demo.FailFastAndException.Business
{
    public class EmployeeService
    {
        private readonly DocumentStore _documentStore;
        private readonly EmployeeRepo _employeeRepo;

        public EmployeeService(DocumentStore documentStore, EmployeeRepo employeeRepo)
        {
            _documentStore = documentStore;
            _employeeRepo = employeeRepo;
        }

        public void UploadDocument(int employeeId)
        {
            // Get Document for this Employee
            var doc = _documentStore.GetDocumentForEmployee(employeeId);
            
            if (doc == null)
            {
                // FailFast Throw Exception and Dont Execute Further logic
                throw new EmployeeServiceException("Document For Employee Not Found");
            }
            
            // Fail Fast for Another Logic
            if (doc.Version > 4)
            {
                throw new EmployeeServiceException("No More Versions are allowed. Please delete older versions");
            }
        }
    }
}