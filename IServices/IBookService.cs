//using CarBookingApp.DTO;
using CarBookingApp.DTO;
using CarBookingApp.Models;
using WebApplication_MVC.Models;
//using WebApplication1.DTO;
//using WebApplication1.Model;
namespace CarBookingApp.IServices
{
    public interface IBookService
    {
        Task<Booking> CreateBookingAsync(ViewModel bookingDto);
        Task<Booking> UpdateBookingAsync(int id, ViewModel bookingDto);
        Task<bool> DeleteBookingAsync(int id);
        Task<List<Booking>> GetBookingsAsync();
        Task<Booking> GetBookingByIdAsync(int id);

        // Add these methods to handle filtering bookings
        Task<List<Booking>> GetBookingsByUserAsync(int userId);
        Task<List<Booking>> GetBookingsByCarAsync(int carId);
        Task<List<Booking>> GetBookingsByDateAsync(DateTime date);

    }
}

