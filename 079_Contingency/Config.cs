﻿using Exiled.API.Interfaces;

namespace Contingency_079;

public class Config : IConfig {
    public bool IsEnabled { get; set; } = true;
    public bool Debug { get; set; }
}