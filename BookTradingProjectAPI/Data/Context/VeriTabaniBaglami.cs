﻿using BookTradingProjectAPI.Models.KitapModel;
using BookTradingProjectAPI.Models.UserModels;
using Microsoft.EntityFrameworkCore;

namespace BookTradingProjectAPI.Data.Context
{
    public class VeriTabaniBaglami : DbContext
    {
        public VeriTabaniBaglami(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Kullanici> Kullanicilar { get; set; }
        public DbSet<Kitap> Kitaplar { get; set; }
    }
}