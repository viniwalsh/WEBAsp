using System.Threading.Tasks;
using Application.AppServices;
using Application.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Mvc.Controllers
{
    public class PoderController : Controller
    {
        private readonly IHeroiAppService _heroiAppService;
        private readonly IPoderAppService _poderAppService;

        public PoderController(
            IHeroiAppService heroiAppService,
            IPoderAppService poderAppService)
        {
            _heroiAppService = heroiAppService;
            _poderAppService = poderAppService;
        }

        // GET: Poder
        public async Task<IActionResult> Index()
        {
            return View(await _poderAppService.GetAllAsync(null));
        }

        // GET: Poder/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var poderViewModel = await _poderAppService.GetByIdAsync(id.Value);
            if (poderViewModel == null)
            {
                return NotFound();
            }

            return View(poderViewModel);
        }

        private async Task PopulateSelectHeros(int? heroiId = null)
        {
            var herois = await _heroiAppService.GetAllAsync(null);

            ViewBag.Herois = new SelectList(
                herois,
                nameof(HeroiViewModel.Id),
                nameof(HeroiViewModel.HeroiNomeCompleto),
                heroiId);
        }

        // GET: Poder/Create
        public async Task<IActionResult> Create()
        {
            await PopulateSelectHeros();

            return View();
        }

        // POST: Poder/Create
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PoderViewModel poderViewModel)
        {
            if (ModelState.IsValid)
            {
                await _poderAppService.AddAsync(poderViewModel);
                return RedirectToAction(nameof(Index));
            }

            await PopulateSelectHeros(poderViewModel.HeroiId);
            return View(poderViewModel);
        }

        // GET: Heroi/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id is null)
            {
                return NotFound();
            }

            var poderViewModel = await _poderAppService.GetByIdAsync(id.Value);
            if (poderViewModel == null)
            {
                return NotFound();
            }

            await PopulateSelectHeros(poderViewModel.HeroiId);

            return View(poderViewModel);
        }

        // POST: Heroi/Edit/5
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, PoderViewModel poderViewModel)
        {
            if (id != poderViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _poderAppService.EditAsync(poderViewModel);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PoderViewModelExists(poderViewModel.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }

            await PopulateSelectHeros(poderViewModel.HeroiId);

            return View(poderViewModel);
        }

        // GET: Poder/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var poderViewModel = await _poderAppService.GetByIdAsync(id.Value);
            if (poderViewModel == null)
            {
                return NotFound();
            }

            return View(poderViewModel);
        }

        // POST: Poder/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var poderViewModel = await _poderAppService.GetByIdAsync(id);
            await _poderAppService.RemoveAsync(poderViewModel);
            return RedirectToAction(nameof(Index));
        }

        private bool PoderViewModelExists(int id)
        {
            return _poderAppService.GetByIdAsync(id) != null;
        }

    }
}