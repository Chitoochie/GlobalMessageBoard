using GlobalMessageBoard.Interfaces;
using GlobalMessageBoard.Models.Data;
using GlobalMessageBoard.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace GlobalMessageBoard.Controllers
{
    public class ChainsController : Controller
    {
        private readonly IChainRepository _chainsRepository;

        public ChainsController(IChainRepository chainsRepository)
        {
            _chainsRepository = chainsRepository;
        }

        // GET: Chains
        public async Task<IActionResult> Index()
        {
            return View(await _chainsRepository.GetAllAsync());
        }

        // GET: Chains/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chain = await _chainsRepository.GetByIdAsync(id.Value);
            if (chain == null)
            {
                return NotFound();
            }

            return View(chain);
        }

        // GET: Chains/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Chains/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Date,UserId,BoardId")] Chain chain)
        {
            if (ModelState.IsValid)
            {
                await _chainsRepository.CreateAsync(chain);
                return RedirectToAction(nameof(Index));
            }
            return View(chain);
        }

        // GET: Chains/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chain = await _chainsRepository.GetByIdAsync(id.Value);
            if (chain == null)
            {
                return NotFound();
            }
            return View(chain);
        }

        // POST: Chains/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Date,UserId,BoardId")] Chain chain)
        {
            if (id != chain.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _chainsRepository.UpdateAsync(chain);
                return RedirectToAction(nameof(Index));
            }
            return View(chain);
        }
        // GET: Chains/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chain = await _chainsRepository.GetByIdAsync(id.Value);
            if (chain == null)
            {
                return NotFound();
            }

            return View(chain);
        }

        // POST: Chains/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var chain = await _chainsRepository.GetByIdAsync(id);
            await _chainsRepository.DeleteAsync(chain);
            return RedirectToAction(nameof(Index));
        }
    }
}
