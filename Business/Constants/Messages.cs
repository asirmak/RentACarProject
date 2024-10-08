﻿using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string CarAdded = "Car is successfully added";
        public static string CarDeleted = "Car is successfully deleted";
        public static string CarUpdated = "Car is successfully updated";
        public static string CarInvalid = "Car name must have at least 2 char and daily price must be higher than 0";
        public static string CarsListed = "Cars are listed.";
        public static string CarCategoryLimitExceeded = "Kategori limiti aşıldı.";
        public static string AuthorizationDenied = "Yetkiniz yok.";

        public static string ColorAdded = "Color is successfully added";
        public static string ColorDeleted = "Color is successfully deleted";
        public static string ColorUpdated = "Color is successfully updated";
        public static string ColorsListed = "Colors are listed.";


        public static string BrandAdded = "Brand is successfully added";
        public static string BrandDeleted = "Brand is successfully deleted";
        public static string BrandUpdated = "Brand is successfully updated";
        public static string BrandsListed = "Brands are listed.";

        public static string UserAdded = "User is successfully added";
        public static string UserDeleted = "User is successfully deleted";
        public static string UserUpdated = "User is successfully updated";
        public static string UsersListed = "Users are listed.";
        public static string UserRegistered = "User is registered";
        public static string UserNotFound = "User is not found!";
        public static string PasswordError = "Password is wrong!";
        public static string SuccessfulLogin = "Logged in successfully.";
        public static string UserAlreadyExists = "User Already Exists";
        public static string AccessTokenCreated = "Access Token is created";



        public static string CustomerAdded = "Customer is successfully added";
        public static string CustomerDeleted = "Customer is successfully deleted";
        public static string CustomerUpdated = "Customer is successfully updated";
        public static string CustomersListed = "Customers are listed.";

        public static string RentalAdded = "Rental is successfully added";
        public static string RentalDeleted = "Rental is successfully deleted";
        public static string RentalUpdated = "Rental is successfully updated";
        public static string RentalsListed = "Rentals are listed.";
        public static string RentalInvalid = "This car cannot be rented between these days";

        public static string ImageAdded = "Image is successfully added";
        public static string ImageDeleted = "Image is successfully deleted";
        public static string ImageUpdated = "Image is successfully updated";
        public static string ImagesListed = "Images are listed.";
        public static string ImageNumberExceeded = "Number of images cannot be more than 5";
    }
}
