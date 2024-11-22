This project is a simple ASP.NET Core Web API that retrieves the top N "best stories" from Hacker News, sorts them by score, and returns them as a JSON response.

---
## Enhancements and Changes
### Given More Time:
 - Caching: Implement caching for top story IDs and story details to reduce API calls and improve performance.
 
 - Rate Limiting: Add middleware to limit request frequency, protecting the Hacker News API from overload.
 
 - Unit Tests: Increase test coverage, including mocking external API calls.
 
 - Pagination: Allow clients to request stories in paginated format for better usability.
 
 - Deployment: Deploy the API to a cloud platform like AWS, Azure, or Heroku for public access.
 
 - Health Checks: Add endpoint health monitoring to ensure system reliability.
 
 - Authentication: Secure the API with authentication and authorization for production use.


## How to Run the Application

### Prerequisites
- [.NET 6 SDK](https://dotnet.microsoft.com/download)
- [Git](https://git-scm.com/)
- A modern web browser for testing (e.g., Chrome, Edge).

### Steps to Run
1. Clone the repository:
   ```bash
   git clone https://github.com/yourusername/HackerNewsAPI.git
   cd HackerNewsAPI
2. Restore the dependencies:
   ```bash
    dotnet restore
3. Build the application:
    ```bash
    dotnet build
4. Run the application:
    ```bash
    dotnet run
    
### Access the API at:

https://localhost:5001/api/stories/best?count=10

### Assumptions
- Story Count: The count query parameter defaults to 10 if not provided.
- Error Handling: Stories that cannot be fetched due to API errors are skipped.
- Sorting: Results are always sorted in descending order by score.

### Project Structure
 - Models: Contains the Story class to represent story data.
 - Services: Includes HackerNewsService for interacting with the Hacker News API.
 - Controllers: Contains the StoriesController to handle API requests.
### Dependencies
 - ASP.NET Core: For building the Web API.
 - Newtonsoft.Json: For JSON serialization and deserialization.
 - HttpClient: For making HTTP requests.
