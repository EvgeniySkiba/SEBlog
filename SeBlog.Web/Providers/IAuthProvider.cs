﻿namespace SeBlog.Web.Providers
{
    public interface IAuthProvider
    {
        bool IsLoggedIn { get; }
        bool Login(string username, string password);
        void Logout();
    }
}