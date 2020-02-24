using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TrashCollector.Data;
using TrashCollector.Models;

namespace TrashCollector.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CustomersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Customers
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Customer.Include(c => c.Account).Include(c => c.Address);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Customers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return RedirectToPage("Login");
            }

            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var customer = _context.Customer
                .Include(c => c.Account)
                .Include(c => c.Address)
                .Where(m => m.ID == id).FirstOrDefault();
            if (customer == null)
            {
                return Create();
            }

            return View(customer);
        }

        // GET: Customers/Create
        public IActionResult Create()
        {
            ViewData["AccountID"] = new SelectList(_context.Set<Account>(), "AccountId", "AccountId");
            ViewData["AddressID"] = new SelectList(_context.Set<Address>(), "AddressID", "AddressID");
            ViewData["IdentityUserId"] = new SelectList(_context.Set<Customer>(), "ID", "ID");
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Customer customer)
        {
            if (ModelState.IsValid)
            {
                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                customer.IdentityUserId = userId;

                _context.Add(customer);
                await _context.SaveChangesAsync();
                return RedirectToAction("CustomerView","Customers");
            }
            ViewData["AccountID"] = new SelectList(_context.Set<Account>(), "AccountId", "AccountId", customer.AccountID);
            ViewData["AddressID"] = new SelectList(_context.Set<Address>(), "AddressID", "AddressID", customer.AddressID);
            ViewData["IdentityUserId"] = new SelectList(_context.Set<Customer>(), "ID", "ID"); 
            return View("CustomerView", customer);
        }

        // GET: Customers/EditCustomer/5
        public async Task<IActionResult> EditCustomer(int AddressID) 
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null)
            {
                return Create();
            }

            var customer = _context.Customer
             .Include(c => c.Address)
             .Where(m => m.IdentityUserId == userId).FirstOrDefault();

            if (customer == null)
            {
                return NotFound();
            }
            ViewData["AddressID"] = new SelectList(_context.Set<Address>(), "AddressID", "AddressID", customer.AddressID);
            ViewData["IdentityUserId"] = new SelectList(_context.Set<Customer>(), "ID", "ID");
            return View("EditCustomer", customer);
        }

        // POST: Customers/EditCustomer/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditCustomer(int id, /*[Bind("ID,FirstName,LastName,StreetAddress,City,State,ZipCode")]*/ Customer customer)
        {
            if (id != customer.ID)
            {
                return NotFound();
            }
            var customerInDB = _context.Customer
                .Include(a=>a.Address)
                .Where(m => m.ID == customer.ID).FirstOrDefault();
            // change me!.
            //var addressInDB = _context.Customer.First(m => m.AddressID == customer.AddressID);

            customerInDB.FirstName = customer.FirstName;
            customerInDB.LastName = customer.LastName;
            customerInDB.Address.StreetAddress = customer.Address.StreetAddress;
            customerInDB.Address.City = customer.Address.City;
            customerInDB.Address.State = customer.Address.State;
            customerInDB.Address.ZipCode = customer.Address.ZipCode;

            _context.SaveChanges();
            return RedirectToAction("CustomerView");

            ViewData["AccountID"] = new SelectList(_context.Set<Account>(), "AccountId", "AccountId", customer.AccountID);
            ViewData["AddressID"] = new SelectList(_context.Set<Address>(), "AddressID", "AddressID", customer.AddressID);
        }

        // GET: Customers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customer
                .Include(c => c.Account)
                .Include(c => c.Address)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var customer = await _context.Customer.FindAsync(id);
            _context.Customer.Remove(customer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CustomerExists(int id)
        {
            return _context.Customer.Any(e => e.ID == id);
        }

        // GET: Customers/CustomerView/5
        public IActionResult CustomerView(int? id)
            {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null)
            {
                return Create();
            }

            var customer = _context.Customer
                .Include(c => c.Account)
                .Include(c => c.Address)
                .Where(m => m.IdentityUserId == userId).FirstOrDefault();
            if (customer == null)
            {
                return Create();
            }

            return View(customer);
        }
        // GET: Customers/EditCustomer/5
        public async Task<IActionResult> EditAccount(int ID)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null)
            {
                return Create();
            }

            var customer = _context.Account
             .Where(m => m.AccountId == ID).First();

            if (customer == null)
            {
                return NotFound();
            }
            return View("EditAccount");
        }

        // POST: Customers/EditCustomer/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditAccountNow(int id, Account account)
        {
            if (id != account.AccountId)
            {
                return NotFound();
            }
            var customerInDB = _context.Account
                .Where(m => m.AccountId == account.AccountId).FirstOrDefault();


            customerInDB.OneTimePickUp = account.OneTimePickUp;
            customerInDB.StartDay = account.StartDay;
            customerInDB.EndDay = account.EndDay;
            customerInDB.PickUpDay = account.PickUpDay;

            _context.SaveChanges();
            return RedirectToAction("CustomerView");

            //ViewData["AccountID"] = new SelectList(_context.Set<Account>(), "AccountId", "AccountId", account.AccountId);
            //ViewData["AddressID"] = new SelectList(_context.Set<Address>(), "AddressID", "AddressID", account.AccountId);
        }
    }
}
