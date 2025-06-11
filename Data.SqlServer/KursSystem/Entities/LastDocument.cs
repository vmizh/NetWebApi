using System;
using System.Collections.Generic;

namespace Data.SqlServer.KursSystem.Entities;

/// <summary>
/// [Display(Name = &quot;Не документ&quot;)] None = 0,
/// 
///         [Display(Name = &quot;Приходный касовый ордер&quot;)]
///         CashIn = 33,
/// 
///         [Display(Name = &quot;Расходный касовый ордер&quot;)]
///         CashOut = 34,
/// 
///         [Display(Name = &quot;Банковская проводка&quot;)]
///         Bank = 101,
///         [Display(Name = &quot;Обмен валюты&quot;)] CurrencyChange = 251,
///         [Display(Name = &quot;Акт взаимозачета&quot;)] MutualAccounting = 110,
///         [Display(Name = &quot;Акт конвертации&quot;)] CurrencyConvertAccounting = 111,
/// 
///         [Display(Name = &quot;Инвентаризационная ведомость&quot;)]
///         InventoryList = 359,
/// 
///         [Display(Name = &quot;Приходный складской ордер&quot;)]
///         StoreOrderIn = 357,
/// 
///         [Display(Name = &quot;Счет-фактура клиентам&quot;)]
///         InvoiceClient = 84,
/// 
///         [Display(Name = &quot;Счет-фактура поставщиков&quot;)]
///         InvoiceProvider = 26,
/// 
///         [Display(Name = &quot;Расходная накладная&quot;)]
///         Waybill = 368,
/// 
///         [Display(Name = &quot;Ведомость начисления заработной платы&quot;)]
///         PayRollVedomost = 903,
/// 
///         [Display(Name = &quot;Акт валютной таксировки номенклатур&quot;)]
///         NomenklTransfer = 10001,
/// 
///         [Display(Name = &quot;Справочник проектов&quot;)]
///         ProjectsReference = 10002
/// </summary>
public partial class LastDocument
{
    public Guid Id { get; set; }

    public Guid UserId { get; set; }

    public Guid DbId { get; set; }

    public int DocType { get; set; }

    public decimal? DocDC { get; set; }

    public Guid? DocId { get; set; }

    public string Creator { get; set; } = null!;

    public string LastChanger { get; set; } = null!;

    public DateTime LastOpen { get; set; }

    public string? Description { get; set; }

    public virtual DataSource Db { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
