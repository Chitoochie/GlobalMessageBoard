using GlobalMessageBoard.Interfaces;
using GlobalMessageBoard.Models.Data;
using Microsoft.AspNetCore.Mvc;

namespace GlobalMessageBoard.Controllers
{
    public class BoardsController : Controller
    {
        private readonly IBoardRepository _repository;

        public BoardsController(IBoardRepository repository)
        {
            _repository = repository;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _repository.GetAllAsync());
        }

        public async Task<IActionResult> Details(int id)
        {
            var board = await _repository.GetByIdAsync(id);
            if (board == null)
            {
                return NotFound();
            }
            return View(board);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Board board)
        {
            if (ModelState.IsValid)
            {
                await _repository.CreateAsync(board);
                return RedirectToAction(nameof(Index));
            }
            return View(board);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var board = await _repository.GetByIdAsync(id);
            if (board == null)
            {
                return NotFound();
            }
            return View(board);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Board board)
        {
            if (id != board.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _repository.UpdateAsync(board);
                return RedirectToAction(nameof(Index));
            }
            return View(board);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var board = await _repository.GetByIdAsync(id);
            if (board == null)
            {
                return NotFound();
            }
            return View(board);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var board = await _repository.GetByIdAsync(id);
            await _repository.DeleteAsync(board);
            return RedirectToAction(nameof(Index));
        }
    }
}
