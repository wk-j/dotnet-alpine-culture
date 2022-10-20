# Wrong!

```csharp
var now = DateTime.Now;
var culture = new CultureInfo("th-TH");
Console.WriteLine(now.ToString("dd MMMM yyyy", culture));
Console.WriteLine(now.ToString("dd MMM yyyy", culture));
```

```
web_1  | 20 October 2565
web_1  | 20 Oct 2565
```