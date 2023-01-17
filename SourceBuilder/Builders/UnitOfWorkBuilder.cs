﻿using SourceBuilder.Builders.Abstract;
using SourceBuilder.Helpers;
using SourceBuilder.Models;

namespace SourceBuilder.Builders;

public class UnitOfWorkBuilder : IBuilder
{
    public void Build(List<Entity> entities)
    {
        var text = TextBuilder.BuildTextForUnitOfWork(entities);
        Workers.SourceBuilder.Instance.AddSourceFile(Constants.UnitOfWorkPath, "UnitOfWork.cs", text);
    }
}