﻿using ECommerceAPI.Dtos.Authentication.Requests;
using ECommerceAPI.Services.AuthenticationServices.Interfaces;
using System.Formats.Asn1;
namespace ECommerceAPI.Endpoints
{
    public class AuthenticationEndpoints
    {
        public static async Task<IResult> Register(IAuthenticationService authenticationService, RegistrationRequestDto registerRequest)
        {
            var response = await authenticationService.RegisterAsync(registerRequest);
            if (response.IsError)
            {
                return Results.BadRequest(response.Errors);
            }
            return Results.Ok(response.Value);
        }
        public static async Task<IResult> ConfirmEmail(IAuthenticationService authenticationService, string email, string token)
        {
            var response = await authenticationService.ConfirmEmailAsync(email, token);
            if (response.IsError)
            {
                return Results.BadRequest(response.Errors);
            }
            return Results.Ok(response.Value);
        }
        public static async Task<IResult> Login(IAuthenticationService authenticationService, LoginRequestDto loginRequest)
        {
            var response = await authenticationService.LoginAsync(loginRequest);
            if (response.IsError)
            {
                return Results.BadRequest(response.Errors);
            }
            return Results.Ok(response.Value);
        }
        public static async Task<IResult> RefreshToken(IAuthenticationService authenticationService, string token)
        {
            var response = await authenticationService.RefreshTokenAsync(token);
            if (response.IsError)
            {
                return Results.BadRequest(response.Errors);
            }
            return Results.Ok(response.Value);
        }
    }
}
