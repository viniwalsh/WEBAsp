using System.Threading.Tasks;
using Application.AppServices;
using Application.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Mvc.Controllers
{
    public class HeroiController : Controller
    {
        private readonly IHeroiAppService _heroiAppService;

        public HeroiController(
            IHeroiAppService heroiAppService)
        {
            _heroiAppService = heroiAppService;
        }

        // GET: Heroi
        public async Task<IActionResult> Index()
        {
            return View(await _heroiAppService.GetAllAsync(null));
        }

        // GET: Heroi/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var heroiViewModel = await _heroiAppService.GetByIdAsync(id.Value);
            if (heroiViewModel == null)
            {
                return NotFound();
            }

            return View(heroiViewModel);
        }

        // GET: Hroi/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Heroi/Create
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Codinome,Lancamento")] HeroiViewModel heroiViewModel)
        {
            if (ModelState.IsValid)
            {
                await _heroiAppService.AddAsync(heroiViewModel);
                return RedirectToAction(nameof(Index));
            }
            return View(heroiViewModel);
        }

        // GET: Heroi/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id is null)
            {
                return NotFound();
            }

            var heroiViewModel = await _heroiAppService.GetByIdAsync(id.Value);
            if (heroiViewModel == null)
            {
                return NotFound();
            }
            return View(heroiViewModel);
        }

        // POST: Heroi/Edit/5
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Codinome,Lancamento")] HeroiViewModel heroiViewModel)
        {
            if (id != heroiViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _heroiAppService.EditAsync(heroiViewModel);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HeroiViewModelExists(heroiViewModel.Id))
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
            return View(heroiViewModel);
        }

        // GET: Heroi/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var heroiViewModel = await _heroiAppService.GetByIdAsync(id.Value);
            if (heroiViewModel == null)
            {
                return NotFound();
            }

            return View(heroiViewModel);
        }

        // POST: Heroi/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var heroiViewModel = await _heroiAppService.GetByIdAsync(id);
            await _heroiAppService.RemoveAsync(heroiViewModel);
            return RedirectToAction(nameof(Index));
        }

        private bool HeroiViewModelExists(int id)
        {
            return _heroiAppService.GetByIdAsync(id) != null;
        }
    }
}