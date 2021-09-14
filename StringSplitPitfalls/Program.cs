using System;


static void UseCase1()
{
    // Extract Info at Second occurence of Seperator ,
    var input1 = "Col1,Col2,Col3,Col4";

    // PitFall
    var res = input1.Split(",")[1];
    
    // Optimized Way (Zero Allocation)
    var span = input1.AsSpan();
    // Do Repetitive Slices without allocation until Index is met. Current case we need only 1 slice
    var sl1 = span.Slice(span.IndexOf(","));
 
    // Only Allocate the result
    res = sl1.Slice(0, sl1.IndexOf(",")).ToString();
    
    // This Method will cost only last allocation no matter how large input string is and what index we want to pick from
}

static void UseCase2()
{
    // Extract Key Value at Second occurence of Seperator ,
    var input1 = "Key1=34,Key2=23,Key4=15,Key7=16";

    // PitFall
    var res = input1.Split(",")[1].Split("=")[1];

    // Follow Use Case 1 and Pass Seperator as Dynamic 
    Func<string, string, string> split = (input, sep) =>
    {
        // Optimized Way (Zero Allocation)
        var span = input.AsSpan();
        // Do Repetitive Slices without allocation until Index is met. Current case we need only 1 slice
        var sl1 = span.Slice(span.IndexOf(sep));
        
        return sl1.Slice(0, sl1.IndexOf(",")).ToString();;
    };

    var in1 = split(input1, ",");
    var in2 = split(in1, "=");
}

