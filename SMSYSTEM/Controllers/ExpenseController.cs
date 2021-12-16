using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SMSYSTEM.Controllers
{
    public class ExpenseController : Controller
    {
        // GET: Expense
        public ActionResult ViewExpenseVouchers()
        {
            return View();
        }
    }
} 