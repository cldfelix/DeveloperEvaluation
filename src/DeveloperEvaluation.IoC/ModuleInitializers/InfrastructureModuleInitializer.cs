﻿using DeveloperEvaluation.Application.Services;
using DeveloperEvaluation.Domain.Repositories;
using DeveloperEvaluation.Domain.Services;
using DeveloperEvaluation.ORM;
using DeveloperEvaluation.ORM.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DeveloperEvaluation.IoC.ModuleInitializers;

public class InfrastructureModuleInitializer : IModuleInitializer
{
    public void Initialize(WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<DbContext>(provider => provider.GetRequiredService<DefaultContext>());
        builder.Services.AddScoped<IPessoaFisicaRepository, PessoaFisicaRepository>();
        builder.Services.AddScoped<IPessoaJuridicaRepository, PessoaJuridicaRepository>();
        builder.Services.AddSingleton<IRedisService, RedisService>();
    }
}