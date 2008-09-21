﻿using System;
using Suteki.Common.Extensions;
using Suteki.Common.Repositories;
using Suteki.Shop.Repositories;
using System.Web;

namespace Suteki.Shop.Services
{
    public class BaseControllerService : IBaseControllerService
    {
        public IRepository<Category> CategoryRepository { get; private set; }
        public IRepository<Content> ContentRepository { get; private set; }
        public string GoogleTrackingCode { get; set; }
        public string MetaDescription { get; set; }
        private string shopName;
        private string emailAddress;
        private string copyright;

        public BaseControllerService(
            IRepository<Category> categoryRepository,
            IRepository<Content> contentRepository)
        {
            this.CategoryRepository = categoryRepository;
            this.ContentRepository = contentRepository;
        }

        public string EmailAddress
        {
            get 
            {
                if (string.IsNullOrEmpty(emailAddress)) return string.Empty;
                return emailAddress; 
            }
            set { emailAddress = value; }
        }

        public string ShopName
        {
            get
            {
                if (string.IsNullOrEmpty(shopName))
                {
                    return "Suteki Shop";
                }
                return shopName;
            }
            set { shopName = value; }
        }

        public virtual string SiteUrl 
        {
            get
            {

                Uri url = CurrentHttpContext.Request.Url;
                string relativePath = CurrentHttpContext.Request.ApplicationPath;
                string port = (url.Port == 80) ? "" : ":{0}".With(url.Port.ToString());

                return "{0}://{1}{2}{3}".With(url.Scheme, url.Host, port, relativePath);
            }
        }

        public virtual HttpContext CurrentHttpContext
        {
            get
            {
                if (HttpContext.Current == null)
                {
                    throw new ApplicationException("There is no current HttpContext");
                }
                return HttpContext.Current;
            }
        }

        public virtual string Copyright
        {
            get
            {
                if (string.IsNullOrEmpty(copyright)) return "Suteki Limited &copy; Copyright 2008";
                return copyright;
            }
            set { copyright = value; }
        }
    }
}
