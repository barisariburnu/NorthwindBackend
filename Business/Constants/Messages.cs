using Core.Entities.Concrete;
using System.Runtime.Serialization;

namespace Business.Constants
{
    public static class Messages
    {
        public static string ProductAdded = "Product added successfully";
        public static string ProductDeleted = "Product deleted successfully";
        public static string ProductUpdated = "Product updated successfully";
        public static string ProductNameAlreadyExists = "Product name already exists in the system";

        public static string CategoryAdded = "Category added successfully";
        public static string CategoryDeleted = "Category deleted successfully";
        public static string CategoryUpdated = "Category updated successfully";

        public static string UserNotFound = "User not found";
        public static string PasswordError = "Password is incorrect";
        public static string SuccessfulLogin = "Login successful";
        public static string UserAlreadyExists = "User already exists";
        public static string UserRegistered = "User registered successfully";
        public static string AccessTokenCreated = "Access token created successfully";
        public static string AuthorizationDenied = "Authorization denied";

    }
}
