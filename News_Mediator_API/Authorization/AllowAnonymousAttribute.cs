﻿namespace News_Mediator_API.Authorization;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public class AllowAnonymousAttribute : Attribute
{ }
