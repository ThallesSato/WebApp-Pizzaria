﻿namespace BackContoso.Services
{
    public interface IAuthenticate
    {
        Task<bool> Authenticate(string username, string password);

        Task<bool> RegisterUser(string username, string password);

        Task Logout();
    }
}
