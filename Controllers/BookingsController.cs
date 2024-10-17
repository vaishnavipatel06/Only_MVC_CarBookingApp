using CarBookingApp.DTO;
using CarBookingApp.IServices;
using Microsoft.AspNetCore.Mvc;

namespace Only_MVC_CarBookingApp.Controllers
{
    public class BookingsController : Controller
    {
        private readonly IBookService _bookingService;

        public BookingsController(IBookService bookingService)
        {
            _bookingService = bookingService;
        }

        // GET: Bookings
        public async Task<IActionResult> Index()
        {
            var bookings = await _bookingService.GetBookingsAsync();
            return View(bookings); // Renders the list of bookings to the view
        }

        // GET: Bookings/Details/5
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var booking = await _bookingService.GetBookingByIdAsync(id);
            if (booking == null)
            {
                return NotFound();
            }

            return View(booking); // Renders details of a specific booking
        }

        // GET: Bookings/Create
        public IActionResult Create()
        {
            return View(); // Displays the Create form view
        }

        // POST: Bookings/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ViewModel bookingDto)
        {
            if (ModelState.IsValid)
            {
                await _bookingService.CreateBookingAsync(bookingDto);
                return RedirectToAction(nameof(Index)); // Redirects to the index page after creating a booking
            }
            return View(bookingDto); // If validation fails, redisplay the form
        }

        // GET: Bookings/Edit/5
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var booking = await _bookingService.GetBookingByIdAsync(id);
            if (booking == null)
            {
                return NotFound();
            }

            var bookingViewModel = new ViewModel
            {
                //CarID = booking.CarID,
                BookingID = booking.BookingID,
                UserID = (int)booking.UserID,
                CarID = (int)booking.CarID,
                Source = booking.Source,
                Destination = booking.Destination,
                BookingDate = booking.BookingDate,
                Status = booking.Status
            };

            return View(bookingViewModel); // Displays the edit form pre-populated with the booking data
        }

        // POST: Bookings/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        //[HttpPut("{id}")]
        public async Task<IActionResult> Edit(int id, ViewModel bookingDto)
        {
            if (ModelState.IsValid)
            {
                var updatedBooking = await _bookingService.UpdateBookingAsync(id, bookingDto);
                if (updatedBooking == null)
                {
                    return NotFound(); // If the booking was not found
                }
                return RedirectToAction(nameof(Index)); // Redirect to the index page after editing
            }
            return View(bookingDto); // If validation fails, redisplay the form
        }

        // GET: Bookings/Delete/5
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var booking = await _bookingService.GetBookingByIdAsync(id);
            if (booking == null)
            {
                return NotFound();
            }

            return View(booking); // Displays the delete confirmation view
        }

        // POST: Bookings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _bookingService.DeleteBookingAsync(id);
            return RedirectToAction(nameof(Index)); // Redirects to the index page after deleting the booking
        }

        // Optional: Filter by User
        public async Task<IActionResult> GetBookingsByUser(int userId)
        {
            var bookings = await _bookingService.GetBookingsByUserAsync(userId);
            return View("Index", bookings); // Reuses the Index view to display filtered bookings
        }

        // Optional: Filter by Car
        public async Task<IActionResult> GetBookingsByCar(int carId)
        {
            var bookings = await _bookingService.GetBookingsByCarAsync(carId);
            return View("Index", bookings); // Reuses the Index view to display filtered bookings
        }

        // Optional: Filter by Date
        public async Task<IActionResult> GetBookingsByDate(DateTime date)
        {
            var bookings = await _bookingService.GetBookingsByDateAsync(date);
            return View("Index", bookings); // Reuses the Index view to display filtered bookings
        }
    }
}