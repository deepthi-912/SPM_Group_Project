using System;
using Appointments_API.Interfaces;
using Appointments_API.Models;
using Appointments_API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Appointments_API.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class AppointmentController : ControllerBase
    {
        private readonly ILogger<AppointmentController> _logger;
        private readonly IAppointmentRepository _todoRepository;
        public AppointmentController(ILogger<AppointmentController> logger, IAppointmentRepository todoRepository)
        {
            _logger = logger;
            _todoRepository = todoRepository;
        }
        /// <summary>
        /// GetItems is to get all the items in the Appointments .
        /// </summary>
        /// <returns>Items list</returns>

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<Appointments>))]

        public IActionResult GetItems()
        {
            _logger.Log(LogLevel.Information, "Get Expenditures");
            return Ok(_todoRepository.GetItems());
        }

        /// <summary>
        /// GetItem function gets appointment details of the ID given.It returns appointments of each ID if it is found else it returns Notfound.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>400(notfound) or item</returns>

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(Appointments))]
        [ProducesResponseType(400)]

        public IActionResult GetItem(int id)
        {
            Appointments item = _todoRepository.GetItem(id);
            if (item == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(item);
            }
        }

        /// <summary>
        /// CreateItem method adds the appointment values in the list.It returns Badrequest message if the values are null
        /// and return Successfully added if the items are added.
        /// </summary>
        /// <param name="todo"></param>
        /// <returns>Bad request message or Success message</returns>
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]

        public IActionResult CreateItem([FromBody] Appointments todo)
        {
            if (todo == null)
            {
                return BadRequest("Expenditure is null");
            }
            bool result = _todoRepository.CreateItem(todo);
            if (result)
            {
                return Ok("Successfully added");
            }
            else
            {
                return BadRequest("Expenditure not added. Check if existing ID is not added!");
            }
        }

        /// <summary>
        /// UpdateItem method updates the values to the items for a given ID. It gets the values if updated or not.
        /// If the given ID is not found, it throws ID not found.If updated successfully, it says updated and if the values are
        /// null, it returns badrequest
        /// </summary>
        /// <param name="id"></param>
        /// <param name="item"></param>
        ///<returns>Item is null or No matching ID or successfully updated</returns>

        [HttpPut]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]

        public IActionResult UpdateItem(Appointments item)
        {
            if (item == null)
            {
                return BadRequest("Item is null");
            }

            bool isUpdated = _todoRepository.UpdateItem(item);

            if (!isUpdated)
            {
                return NotFound("No matching ID");
            }
            else
            {
                return Ok("Successfully updated");
            }
        }

        /// <summary>
        /// DeleteItem deletes the appointment value for a given ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>No maching id or Item deleted</returns>

        //[HttpDelete]
        [HttpDelete("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult DeleteItem(int id)
        {
            bool deleted = _todoRepository.DeleteItem(id);
            if (!deleted)
            {
                return NotFound("No matching ID");
            }

            else
            {
                return Ok("Item deleted");
            }
        }


        /// <summary>
        /// GetAppointmentsCount method gives the count expenditure of the values.
        /// </summary>
        /// <returns>mean</returns>
        [HttpGet("Analysis-GetAppointmentsCount")]
        [ProducesResponseType(200, Type = typeof(int))]

        public IActionResult GetAppointmentsCount()
        {
            return Ok(_todoRepository.getTotalAppointmentsCount());
        }

        /// <summary>
        /// GetAppointmentsByDate method gets the appointments by date.
        /// </summary>
        /// <returns>appointments by date</returns>
        [HttpGet("Analysis-GetAppointmentsByDate")]
        [ProducesResponseType(200, Type = typeof(List<Appointments>))]

        public IActionResult getAppointmentsByDate(DateTime dt)
        {
            return Ok(_todoRepository.getAppointmentsByDate(dt));
        }

        /// <summary>
        /// GetAppointmentsBetweenDates method gets the appointments between dates.
        /// </summary>
        /// <returns>Appointments Between Dates</returns>
        [HttpGet("Analysis-GetAppointmentsBetweenDates")]
        [ProducesResponseType(200, Type = typeof(List<Appointments>))]

        public IActionResult getAppointmentsBetweenDates(DateTime dt1, DateTime dt2)
        {
            return Ok(_todoRepository.getAppointmentsBetweenDates(dt1, dt2));
        }

        /// <summary>
        /// GetAppointmentsByDoctor method gets the appointments by doctor.
        /// </summary>
        /// <returns>Appointments By Doctor id</returns>
        [HttpGet("Analysis-GetAppointmentsByDoctor")]
        [ProducesResponseType(200, Type = typeof(List<Appointments>))]

        public IActionResult getAppointmentsByDoctor(int dId)
        {
            return Ok(_todoRepository.getAppointmentsByDoctor(dId));
        }

        /// <summary>
        /// GetAppointmentsByPatient method gets the appoimtments by patient.
        /// </summary>
        /// <returns>Appointments By Patient</returns>
        [HttpGet("Analysis-GetAppointmentsByPatient")]
        [ProducesResponseType(200, Type = typeof(List<Appointments>))]

        public IActionResult getAppointmentsByPatient(int pid)
        {
            return Ok(_todoRepository.getAppointmentsByPatient(pid));
        }

        /// <summary>
        /// GetAppointmentsByPatient method gets the appoimtments by patient.
        /// </summary>
        /// <returns>Appointments By Patient</returns>
        [HttpGet("Analysis-GetAppointmentsByDisease")]
        [ProducesResponseType(200, Type = typeof(List<Appointments>))]

        public IActionResult getAppointmentsByDisease(string disease)
        {
            return Ok(_todoRepository.getAppointmentsByDisease(disease));
        }
    }
}

