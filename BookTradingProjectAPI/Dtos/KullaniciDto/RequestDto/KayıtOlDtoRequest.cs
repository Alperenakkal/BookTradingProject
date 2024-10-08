﻿using BookTradingProjectAPI.Models.UserModels;

namespace BookTradingProjectAPI.Dtos.KullaniciDto.RequestDto
{
    public class KayıtOlDtoRequest
    {

        public required string KullaniciAdi { get; set; }
        public string AdSoyad { get; set; }
        public required string Sifre { get; set; }
        public required string SifreTekrari { get; set; }
        public string Mail { get; set; }
        public CinsiyetTipi cinsiyet { get; set; }
        public string TelefonNo { get; set; }
        public string Sehir { get; set; } = string.Empty;
        public string Mahalle { get; set; } = string.Empty;

    }

}
