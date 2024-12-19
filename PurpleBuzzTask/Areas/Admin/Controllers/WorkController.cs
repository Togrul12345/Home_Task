using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PurpleBuzzTask.DAL;
using PurpleBuzzTask.DTOs;
using PurpleBuzzTask.DTOs.WorkDTOs;
using PurpleBuzzTask.Models;
using PurpleBuzzTask.Utilities;
using PurpleBuzzTask.ViewModel;
using System.Collections.Generic;

namespace PurpleBuzzTask.Areas.Admin.Controllers
{

    [Area("Admin")]

    public class WorkController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        public readonly AppDbContext _context;
        public WorkController(AppDbContext appDbContext, IWebHostEnvironment webHostEnvironment)
        {
            _context = appDbContext;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {



            return View(_context.Works);

        }
        public IActionResult Create()
        {
            ViewBag.Services = _context.Services;
            ViewBag.Employees = new SelectList(_context.Employees, "Id", "Name");
            return View();
        }
        [HttpPost]
        public IActionResult Create(CreateWorkDTO workCreated)
        {
            if (ModelState.IsValid)
            {
                Service? service = _context.Services.Find(workCreated.ServiceId);
                foreach (var item in workCreated.EmployeIds)
                {
                    if (!_context.Employees.Any(a => a.Id == item))
                    {
                        return NotFound();
                    };
                }
                if (service != null)
                {
                    Work work = new Work()
                    {
                        ServiceId = service.Id,
                        Title = workCreated.Title,
                        Description = workCreated.Description,
                        CreatedAt = DateTime.Now,
                        MainImgUrl = workCreated.MainImg.UploadImage(_webHostEnvironment.WebRootPath, Path.Combine("Upload", "MainImg"))


                    };
                    _context.Works.Add(work);
                    foreach (var item in workCreated.WorkPhotos ?? new List<IFormFile>())
                    {
                        WorkPhoto workPhoto = new WorkPhoto()
                        {
                            ImgUrl = item.UploadImage(_webHostEnvironment.WebRootPath, Path.Combine("Upload", "AdditionalImgs")),

                            IsCover = true,
                            Work = work

                        };

                        _context.WorkPhotos.Add(workPhoto);
                    }
                    foreach (var item in workCreated.EmployeIds)
                    {
                        EmployeeWork employeeWork = new EmployeeWork()
                        {
                            EmployeeId = item,
                            Work = work
                        };
                        _context.EmployeeWorks.Add(employeeWork);
                    }


                    _context.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }





            }
            ViewBag.Services = _context.Services;
            ViewBag.Employees = new SelectList(_context.Employees, "Id", "Name");
            ModelState.AddModelError("ServiceId", "Service is incorrect");
            return View(workCreated);






        }
        public IActionResult Update(int id)
        {
            Work? work = _context.Works.Include(a => a.WorkPhotos).FirstOrDefault(q => q.Id == id);
            if (work == null)
            {
                return BadRequest();
            }
            UpdateWorkDTO updateWorkDTO = new UpdateWorkDTO()
            {
                Title = work.Title,
                Description = work.Description,
                ExistingMainImgUrl = work.MainImgUrl,
                ExistingPhotos = work.WorkPhotos
            };
            return View(updateWorkDTO);
        }
        [HttpPost]
        public IActionResult Update(UpdateWorkDTO updateWorkDTO)
        {
            if (ModelState.IsValid)
            {
                Work? existingWork = _context.Works.Find(updateWorkDTO.Id);
                if (existingWork is null)
                {
                    return BadRequest("something went wrong");
                }
                if (updateWorkDTO.NewPhotos != null && updateWorkDTO.NewPhotos.Count() > 0)
                {
                    foreach(IFormFile photo in updateWorkDTO.NewPhotos)
                    {
                        if (!photo.CheckType())
                        {
                            ModelState.AddModelError("NewPhotos", "type is incorrect");
                            return View();
                        }
                        if (!photo.CheckSize(6))
                        {
                            ModelState.AddModelError("NewPhotos", "size is incorrect");
                            return View();
                        }
                    }
                    List<WorkPhoto> updatedPhotos = new List<WorkPhoto>();
                    existingWork.Title = updateWorkDTO.Title;
                    existingWork.CreatedAt = DateTime.Now;
                    existingWork.Description = updateWorkDTO.Description;
                    existingWork.MainImgUrl = updateWorkDTO.NewMainImg.UploadImage(_webHostEnvironment.WebRootPath, Path.Combine("Upload", "MainImg"));
                    
                    foreach(IFormFile photo in updateWorkDTO.NewPhotos)
                    {
                        string imgUrl = photo.UploadImage(_webHostEnvironment.WebRootPath,Path.Combine("Upload", "AdditionalImgs"));
                        WorkPhoto workPhoto = new WorkPhoto()
                        {
                            Work = existingWork,
                            ImgUrl = imgUrl,
                        };
                        updatedPhotos.Add(workPhoto);
                        
                    }
                    _context.WorkPhotos.AddRange(updatedPhotos);
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            return View(updateWorkDTO);
        }
        public IActionResult DeleteWorkPhoto(int Id)
        {
            WorkPhoto? deletedPhoto = _context.WorkPhotos.Include(a => a.Work).FirstOrDefault(w => w.Id == Id);
            if (deletedPhoto == null)
            {
                return BadRequest("dont found");
            }
            System.IO.File.Delete(Path.Combine(_webHostEnvironment.WebRootPath, "Upload", "AdditionalImgs", $"{deletedPhoto.ImgUrl}"));
            _context.WorkPhotos.Remove(deletedPhoto);
            _context.SaveChanges();
            return RedirectToAction(nameof(Update), new { deletedPhoto.Work.Id });
        }
    }
}


