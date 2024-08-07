﻿using ErrorOr;
namespace ECommerceAPI.ErrorHandling.IdentityErrors
{
    public static class IdentityErrors
    {
        public static readonly Error InvalidToken = Error.Validation(
            code: "InvalidToken",
            description: "The provided token is invalid.");
        public static readonly Error UserNotFound = Error.NotFound(
            code: "UserNotFound",
            description: "User does not exist.");
        public static readonly Error UserAlreadyExists = Error.Conflict(
            code: "UserAlreadyExists",
            description: "User already exists.");
        public static readonly Error UserCreationFailed = Error.Failure(
            code: "UserCreationFailed",
            description: "Failed to create the user.");
        public static readonly Error EmailNotConfirmed = Error.Unauthorized(
            code: "EmailNotConfirmed",
            description: "Email not confirmed.");
        public static readonly Error InvalidCredentials = Error.Unauthorized(
            code: "InvalidCredentials",
            description: "Invalid credentials.");
        public static readonly Error Unauthenticated = Error.Unauthorized(
            code: "Unauthenticated",
            description: "User is not authenticated.");
        public static readonly Error ChangePasswordFailed = Error.Failure(
            code: "ChangePasswordFailed",
            description: "Failed to change the password.");
    }
}
