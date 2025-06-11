using System;
using System.Collections.Generic;

namespace Data.SqlServer.KursSystem.Entities;

/// <summary>
/// Права центров ответственности на объекты(контр-ты,склады,кассы,банк.счета, товары)
/// </summary>
public partial class ObjectRightResposibilityCenter
{
    public Guid Id { get; set; }

    /// <summary>
    /// 1-Контрагенты, 2-Склады, 3-Кассы, 4-Банк.Счета, 5-Товары
    /// </summary>
    public short ObjectTypeId { get; set; }

    public decimal RespCentDC { get; set; }

    public decimal ObjectDC { get; set; }

    public string? Note { get; set; }
}
