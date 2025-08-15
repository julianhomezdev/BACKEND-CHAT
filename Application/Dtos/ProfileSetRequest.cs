namespace ChatAll.Application.Dtos
{
    public class ProfileSetRequest
    {
        // Dto to receive the request to update the description and profile img in the db
        public string Description { get; set; }

        public string ProfilePhotoUrl { get; set; } 

        public string Email { get; set; }
    }
}
