﻿namespace LoginApi.Dto
{
    public class ChangeUserPassword
    {
        public string Username { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
    }
}
