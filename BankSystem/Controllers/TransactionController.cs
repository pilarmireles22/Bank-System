using BankSystem.DTO;
using BankSystem.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace BankSystem.Controllers
{
    public class TransactionController : ApiController
    {
        private TransactionService _transactionService;
        public TransactionController()
        {
            _transactionService = new TransactionService();
        }

        [HttpPost]
        [Route("api/Transaction")]
        public IHttpActionResult Add(TransactionDTO transactionDTO)
        {
            try
            {
                _transactionService.SaveTransaction(transactionDTO.FromAccountNumber, transactionDTO.ToAccountNumber, transactionDTO.Amount);
                return Ok();
            }
            catch (FromAccountNotExistsException e) { return ErrorHandler(e.Message, e.ErrorCode); }
            catch (ToAccountNotExistsException e) { return ErrorHandler(e.Message, e.ErrorCode); }
            catch (FromAccountNotHaveBalanceException e) { return ErrorHandler(e.Message, e.ErrorCode); }
            catch (LimitAmountException e) { return ErrorHandler(e.Message, e.ErrorCode); }
            catch (AmountGreaterThanZeroException e) { return ErrorHandler(e.Message, e.ErrorCode); }
            
        }
        
        private IHttpActionResult ErrorHandler(string message, string code)
        {
            return Content(HttpStatusCode.ExpectationFailed, new ErrorDTO { Message = message, Code = code });
        }
    }
}