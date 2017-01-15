# Byte-array-to-Int32-converter
Convert byte array to Int32 on C# 6.0

This method takes a byte array and converts it to an Int32.
Here is the body of the method:

```csharp
public static int ConvertByteArrayToInt32(byte[] bytes)
{
       var binary = bytes.Reverse().Select(x => Convert.ToString(x, 2).PadLeft(8, '0')).SelectMany(x => x).ToArray();

       var result = 0;
       for (int i = 0; i < binary.Length; i++)
            if (binary[binary.Length - i - 1] == '1') result += (int)Math.Pow(2, i);

       return result;
}
```

After measuring the performances of `BitConverter` from `System.Diagnostics`, my custom converter and @tigranv 's `FromByteToInt1`, the outcome reveals that you **don't need to reinvent the wheel**. Everything you need exists already in the language, you just need to find its place. :+1:

<img width="419" alt="untitled" src="https://cloud.githubusercontent.com/assets/25085025/21965065/7de2afce-db71-11e6-8683-31cd99fc3991.png">
