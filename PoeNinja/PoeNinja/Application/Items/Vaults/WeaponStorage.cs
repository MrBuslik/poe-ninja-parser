// <copyright file="WeaponStorage.cs" company="YLazakovich">
// Copyright (c) YLazakovich. All rights reserved.
// </copyright>

namespace PoeNinja.Application.Items.Vaults
{
    using System.Collections.Generic;
    using Models;
    using Newtonsoft.Json;

    public class WeaponStorage
    {
        [JsonProperty("lines")]
        public List<Weapon> Weapons { get; private set; }
    }
}