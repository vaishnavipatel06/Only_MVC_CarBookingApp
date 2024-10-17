
//using AutoMapper;
//using CarBookingApp.Data;
using CarBookingApp.DTO;
//using CarBookingApp.ExceptionHandling;
using CarBookingApp.IServices;
using CarBookingApp.Models;
using System.Text.Json;
using System.Text;
using WebApplication_MVC.Models;
//using Microsoft.EntityFrameworkCore;
//using WebApplication1.Data;
//using WebApplication1.DTO;
//using WebApplication1.IBookServices;
//using WebApplication1.Model;

namespace CarBookingApp.Services
{
    public class BookService : IBookService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _config;
        private readonly List<Booking> _bookings = new List<Booking>(); // In-memory cache for demo
        string url = "";

        public BookService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _config = configuration;
            url = _config["apisettings:bookingUrl"]; // Load API URL from configuration
        }

        // Create a new booking
        public async Task<Booking> CreateBookingAsync(ViewModel bookingDto)
        {
            var json = JsonSerializer.Serialize(bookingDto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(url, content);
            response.EnsureSuccessStatusCode();

            var jsonResponse = await response.Content.ReadAsStringAsync();
            var addedBooking = JsonSerializer.Deserialize<Booking>(jsonResponse, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            // Add to the in-memory cache
            _bookings.Add(addedBooking);
            return addedBooking;
        }

        // Update an existing booking
        public async Task<Booking> UpdateBookingAsync(int id, ViewModel bookingDto)
        {
            var json = JsonSerializer.Serialize(bookingDto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync($"{url}/{id}", content);
            response.EnsureSuccessStatusCode();

            var jsonResponse = await response.Content.ReadAsStringAsync();
            var updatedBooking = JsonSerializer.Deserialize<Booking>(jsonResponse, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            return updatedBooking;
        }

        // Delete a booking
        public async Task<bool> DeleteBookingAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"{url}/{id}");
            response.EnsureSuccessStatusCode();

            var bookingToDelete = _bookings.FirstOrDefault(b => b.BookingID == id);
            if (bookingToDelete != null)
            {
                _bookings.Remove(bookingToDelete);
            }

            return response.IsSuccessStatusCode;
        }

        // Get all bookings
        public async Task<List<Booking>> GetBookingsAsync()
        {
            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();

            var jsonResponse = await response.Content.ReadAsStringAsync();
            var bookings = JsonSerializer.Deserialize<List<Booking>>(jsonResponse, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            return bookings;
        }

        // Get a booking by ID
        public async Task<Booking> GetBookingByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"{url}/{id}");
            response.EnsureSuccessStatusCode();

            var jsonResponse = await response.Content.ReadAsStringAsync();
            var booking = JsonSerializer.Deserialize<Booking>(jsonResponse, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            return booking;
        }

        // Get bookings by user
        public async Task<List<Booking>> GetBookingsByUserAsync(int userId)
        {
            var response = await _httpClient.GetAsync($"{url}/user/{userId}");
            response.EnsureSuccessStatusCode();

            var jsonResponse = await response.Content.ReadAsStringAsync();
            var bookings = JsonSerializer.Deserialize<List<Booking>>(jsonResponse, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            return bookings;
        }

        // Get bookings by car
        public async Task<List<Booking>> GetBookingsByCarAsync(int carId)
        {
            var response = await _httpClient.GetAsync($"{url}/car/{carId}");
            response.EnsureSuccessStatusCode();

            var jsonResponse = await response.Content.ReadAsStringAsync();
            var bookings = JsonSerializer.Deserialize<List<Booking>>(jsonResponse, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            return bookings;
        }

        // Get bookings by date
        public async Task<List<Booking>> GetBookingsByDateAsync(DateTime date)
        {
            var response = await _httpClient.GetAsync($"{url}/date/{date.ToString("yyyy-MM-dd")}");
            response.EnsureSuccessStatusCode();

            var jsonResponse = await response.Content.ReadAsStringAsync();
            var bookings = JsonSerializer.Deserialize<List<Booking>>(jsonResponse, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            return bookings;
        }
    }
}



