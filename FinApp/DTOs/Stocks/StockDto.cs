﻿using System;
using FinApp.DTOs.Comment;
using FinApp.DTOs.Comments;

namespace FinApp.DTOs.Stock;

public class StockDto
{
    public Guid Id { get; set; }
    
    public string Symbol { get; set; } = string.Empty;
    
    public string CompanyName { get; set; } = string.Empty;
    
    public decimal Purchase { get; set; }   
    
    public decimal LastDiv { get; set; }

    public string Industry { get; set; } = string.Empty;
    public long MarketCap { get; set; }
    
    public List<CommentDto>? Comments { get; set; } 
}