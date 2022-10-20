# Wrong!

```csharp
var now = DateTime.Now;
var culture = new CultureInfo("th-TH");
Console.WriteLine(now.ToString("dd MMMM yyyy", culture));
Console.WriteLine(now.ToString("dd MMM yyyy", culture));
```

# Output

```
alpine_1  | 20 October 2565
alpine_1  | 20 Oct 2565

ubuntu_1  | 20 ตุลาคม 2565
ubuntu_1  | 20 ต.ค. 2565
```