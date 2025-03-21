﻿namespace Bit.BlazorUI.Demo.Client.Core.Pages.Components.Chart;

public partial class _BitChartTimeDemo
{
    private const int INITAL_COUNT = 5;

    private BitChart _chart = default!;
    private BitChartLineConfig _config = default!;

    protected override void OnInitialized()
    {
        _config = new BitChartLineConfig
        {
            Options = new BitChartLineOptions
            {
                Responsive = true,
                Title = new BitChartOptionsTitle
                {
                    Display = true,
                    Text = "BitChart Time Scale Chart"
                },
                Tooltips = new BitChartTooltips
                {
                    Mode = BitChartInteractionMode.Nearest,
                    Intersect = true
                },
                Hover = new BitChartHover
                {
                    Mode = BitChartInteractionMode.Nearest,
                    Intersect = true
                },
                Scales = new BitChartScales
                {
                    XAxes = new List<BitChartCartesianAxis>
                    {
                        new BitChartTimeAxis
                        {
                            ScaleLabel = new BitChartScaleLabel
                            {
                                LabelString = "Date"
                            },
                            Time = new BitChartTimeOptions
                            {
                                TooltipFormat = "dd MMM HH:mm"
                            },
                        }
                    },
                    YAxes = new List<BitChartCartesianAxis>
                    {
                        new BitChartLinearCartesianAxis
                        {
                            ScaleLabel = new BitChartScaleLabel
                            {
                                LabelString = "Value"
                            }
                        }
                    }
                }
            }
        };

        _config.Data.Labels.AddRange(BitChartDemoUtils.GetNextDays(INITAL_COUNT).Select(d => d.ToString("o")));

        IDataset<int> dataset1 = new BitChartLineDataset<int>(BitChartDemoUtils.RandomScalingFactor(INITAL_COUNT))
        {
            Label = "My first dataset",
            BackgroundColor = BitChartColorUtil.FromDrawingColor(BitChartDemoColors.Red),
            BorderColor = BitChartColorUtil.FromDrawingColor(BitChartDemoColors.Red),
            Fill = BitChartFillingMode.Disabled
        };

        IDataset<int> dataset2 = new BitChartLineDataset<int>(BitChartDemoUtils.RandomScalingFactor(INITAL_COUNT))
        {
            Label = "My second dataset",
            BackgroundColor = BitChartColorUtil.FromDrawingColor(BitChartDemoColors.Blue),
            BorderColor = BitChartColorUtil.FromDrawingColor(BitChartDemoColors.Blue),
            Fill = BitChartFillingMode.Disabled
        };

        IDataset<BitChartTimePoint> dataset3 = new BitChartLineDataset<BitChartTimePoint>()
        {
            Label = "Dataset with point data",
            BackgroundColor = BitChartColorUtil.FromDrawingColor(BitChartDemoColors.Green),
            BorderColor = BitChartColorUtil.FromDrawingColor(BitChartDemoColors.Green),
            Fill = BitChartFillingMode.Disabled
        };

        DateTime now = DateTime.Now;
        dataset3.Add(new BitChartTimePoint(now, BitChartDemoUtils.RandomScalingFactor()));
        dataset3.Add(new BitChartTimePoint(now.AddDays(2), BitChartDemoUtils.RandomScalingFactor()));
        dataset3.Add(new BitChartTimePoint(now.AddDays(3), BitChartDemoUtils.RandomScalingFactor()));
        dataset3.Add(new BitChartTimePoint(now.AddDays(4), BitChartDemoUtils.RandomScalingFactor()));

        _config.Data.Datasets.Add(dataset1);
        _config.Data.Datasets.Add(dataset2);
        _config.Data.Datasets.Add(dataset3);
    }

    private void RandomizeData()
    {
        foreach (IBitChartDataset dataset in _config.Data.Datasets)
        {
            if (dataset is IDataset<BitChartTimePoint> pointDataset)
            {
                for (int i = 0; i < pointDataset.Count; i++)
                {
                    pointDataset[i] = new BitChartTimePoint(pointDataset[i].Time, BitChartDemoUtils.RandomScalingFactor());
                }
            }
            else if (dataset is IDataset<int> intDataset)
            {
                int count = intDataset.Count;
                intDataset.Clear();
                intDataset.AddRange(BitChartDemoUtils.RandomScalingFactor(count));
            }
        }

        _chart.Update();
    }

    private void AddDataset()
    {
        string color = BitChartColorUtil.FromDrawingColor(BitChartDemoColors.All[_config.Data.Datasets.Count % BitChartDemoColors.All.Count]);
        IDataset<int> dataset = new BitChartLineDataset<int>(BitChartDemoUtils.RandomScalingFactor(_config.Data.Labels.Count))
        {
            Label = $"Dataset {_config.Data.Datasets.Count}",
            BackgroundColor = color,
            BorderColor = color,
            Fill = BitChartFillingMode.Disabled
        };

        _config.Data.Datasets.Add(dataset);
        _chart.Update();
    }

    private void RemoveDataset()
    {
        IList<IBitChartDataset> datasets = _config.Data.Datasets;
        if (datasets.Count == 0)
            return;

        datasets.RemoveAt(datasets.Count - 1);
        _chart.Update();
    }

    private void AddData()
    {
        if (_config.Data.Datasets.Count == 0)
            return;

        DateTime now = DateTime.Now;
        _config.Data.Labels.Add(now.AddDays(_config.Data.Labels.Count).ToString("o"));

        foreach (IBitChartDataset dataset in _config.Data.Datasets)
        {
            if (dataset is IDataset<BitChartTimePoint> pointDataset)
            {
                pointDataset.Add(new BitChartTimePoint(now.AddDays(pointDataset.Count), BitChartDemoUtils.RandomScalingFactor()));
            }
            else if (dataset is IDataset<int> intDataset)
            {
                intDataset.Add(BitChartDemoUtils.RandomScalingFactor());
            }
        }

        _chart.Update();
    }

    private void RemoveData()
    {
        if (_config.Data.Datasets.Count == 0)
            return;

        IList<string> labels = _config.Data.Labels;
        if (labels.Count > 0)
            labels.RemoveAt(labels.Count - 1);

        foreach (IBitChartDataset dataset in _config.Data.Datasets)
        {
            if (dataset is IDataset<BitChartTimePoint> pointDataset &&
                pointDataset.Count > 0)
            {
                pointDataset.RemoveAt(pointDataset.Count - 1);
            }
            else if (dataset is IDataset<int> intDataset &&
                     intDataset.Count > 0)
            {
                intDataset.RemoveAt(intDataset.Count - 1);
            }
        }

        _chart.Update();
    }



    private readonly string htmlCode = @"
<BitChart Config=""_config"" IsDateAdapterRequired=""true"" @ref=""_chart"" />

<div>
    <BitButton OnClick=""RandomizeData"">Randomize Data</BitButton>
    <BitButton OnClick=""AddDataset"">Add Dataset</BitButton>
    <BitButton OnClick=""RemoveDataset"">Remove Dataset</BitButton>
    <BitButton OnClick=""AddData"">Add Data</BitButton>
    <BitButton OnClick=""RemoveData"">Remove Data</BitButton>
</div>";
    private readonly string csharpCode = @"
private const int INITAL_COUNT = 5;

private BitChart _chart = default!;
private BitChartLineConfig _config = default!;


protected override void OnInitialized()
{
    _config = new BitChartLineConfig
    {
        Options = new BitChartLineOptions
        {
            Responsive = true,
            Title = new BitChartOptionsTitle
            {
                Display = true,
                Text = ""ChartJs.Blazor Time Scale Chart""
            },
            Tooltips = new BitChartTooltips
            {
                Mode = BitChartInteractionMode.Nearest,
                Intersect = true
            },
            Hover = new BitChartHover
            {
                Mode = BitChartInteractionMode.Nearest,
                Intersect = true
            },
            Scales = new BitChartScales
            {
                XAxes = new List<BitChartCartesianAxis>
                {
                    new BitChartTimeAxis
                    {
                        ScaleLabel = new BitChartScaleLabel
                        {
                            LabelString = ""Date""
                        },
                        Time = new BitChartTimeOptions
                        {
                            TooltipFormat = ""ll HH:mm""
                        },
                    }
                },
                YAxes = new List<BitChartCartesianAxis>
                {
                    new BitChartLinearCartesianAxis
                    {
                        ScaleLabel = new BitChartScaleLabel
                        {
                            LabelString = ""Value""
                        }
                    }
                }
            }
        }
    };

    _config.Data.Labels.AddRange(BitChartDemoUtils.GetNextDays(INITAL_COUNT).Select(d => d.ToString(""o"")));

    IDataset<int> dataset1 = new BitChartLineDataset<int>(BitChartDemoUtils.RandomScalingFactor(INITAL_COUNT))
    {
        Label = ""My first dataset"",
        BackgroundColor = BitChartColorUtil.FromDrawingColor(BitChartDemoColors.Red),
        BorderColor = BitChartColorUtil.FromDrawingColor(BitChartDemoColors.Red),
        Fill = BitChartFillingMode.Disabled
    };

    IDataset<int> dataset2 = new BitChartLineDataset<int>(BitChartDemoUtils.RandomScalingFactor(INITAL_COUNT))
    {
        Label = ""My second dataset"",
        BackgroundColor = BitChartColorUtil.FromDrawingColor(BitChartDemoColors.Blue),
        BorderColor = BitChartColorUtil.FromDrawingColor(BitChartDemoColors.Blue),
        Fill = BitChartFillingMode.Disabled
    };

    IDataset<BitChartTimePoint> dataset3 = new BitChartLineDataset<BitChartTimePoint>()
    {
        Label = ""Dataset with point data"",
        BackgroundColor = BitChartColorUtil.FromDrawingColor(BitChartDemoColors.Green),
        BorderColor = BitChartColorUtil.FromDrawingColor(BitChartDemoColors.Green),
        Fill = BitChartFillingMode.Disabled
    };

    DateTime now = DateTime.Now;
    dataset3.Add(new BitChartTimePoint(now, BitChartDemoUtils.RandomScalingFactor()));
    dataset3.Add(new BitChartTimePoint(now.AddDays(2), BitChartDemoUtils.RandomScalingFactor()));
    dataset3.Add(new BitChartTimePoint(now.AddDays(3), BitChartDemoUtils.RandomScalingFactor()));
    dataset3.Add(new BitChartTimePoint(now.AddDays(4), BitChartDemoUtils.RandomScalingFactor()));

    _config.Data.Datasets.Add(dataset1);
    _config.Data.Datasets.Add(dataset2);
    _config.Data.Datasets.Add(dataset3);
}

private void RandomizeData()
{
    foreach (IBitChartDataset dataset in _config.Data.Datasets)
    {
        if (dataset is IDataset<BitChartTimePoint> pointDataset)
        {
            for (int i = 0; i < pointDataset.Count; i++)
            {
                pointDataset[i] = new BitChartTimePoint(pointDataset[i].Time, BitChartDemoUtils.RandomScalingFactor());
            }
        }
        else if (dataset is IDataset<int> intDataset)
        {
            int count = intDataset.Count;
            intDataset.Clear();
            intDataset.AddRange(BitChartDemoUtils.RandomScalingFactor(count));
        }
    }

    _chart.Update();
}

private void AddDataset()
{
    string color = BitChartColorUtil.FromDrawingColor(BitChartDemoColors.All[_config.Data.Datasets.Count % BitChartDemoColors.All.Count]);
    IDataset<int> dataset = new BitChartLineDataset<int>(BitChartDemoUtils.RandomScalingFactor(_config.Data.Labels.Count))
    {
        Label = $""Dataset {_config.Data.Datasets.Count}"",
        BackgroundColor = color,
        BorderColor = color,
        Fill = BitChartFillingMode.Disabled
    };

    _config.Data.Datasets.Add(dataset);
    _chart.Update();
}

private void RemoveDataset()
{
    IList<IBitChartDataset> datasets = _config.Data.Datasets;
    if (datasets.Count == 0)
        return;

    datasets.RemoveAt(datasets.Count - 1);
    _chart.Update();
}

private void AddData()
{
    if (_config.Data.Datasets.Count == 0)
        return;

    DateTime now = DateTime.Now;
    _config.Data.Labels.Add(now.AddDays(_config.Data.Labels.Count).ToString(""o""));

    foreach (IBitChartDataset dataset in _config.Data.Datasets)
    {
        if (dataset is IDataset<BitChartTimePoint> pointDataset)
        {
            pointDataset.Add(new BitChartTimePoint(now.AddDays(pointDataset.Count), BitChartDemoUtils.RandomScalingFactor()));
        }
        else if (dataset is IDataset<int> intDataset)
        {
            intDataset.Add(BitChartDemoUtils.RandomScalingFactor());
        }
    }

    _chart.Update();
}

private void RemoveData()
{
    if (_config.Data.Datasets.Count == 0)
        return;

    IList<string> labels = _config.Data.Labels;
    if (labels.Count > 0)
        labels.RemoveAt(labels.Count - 1);

    foreach (IBitChartDataset dataset in _config.Data.Datasets)
    {
        if (dataset is IDataset<BitChartTimePoint> pointDataset &&
            pointDataset.Count > 0)
        {
            pointDataset.RemoveAt(pointDataset.Count - 1);
        }
        else if (dataset is IDataset<int> intDataset &&
                    intDataset.Count > 0)
        {
            intDataset.RemoveAt(intDataset.Count - 1);
        }
    }

    _chart.Update();
}

public static class BitChartDemoColors
{
    private static readonly Lazy<IReadOnlyList<System.Drawing.Color>> _all = new Lazy<IReadOnlyList<System.Drawing.Color>>(() => new System.Drawing.Color[7]
    {
                Red, Orange, Yellow, Green, Blue, Purple, Grey
    });

    public static IReadOnlyList<System.Drawing.Color> All => _all.Value;

    public static readonly System.Drawing.Color Red = System.Drawing.Color.FromArgb(255, 99, 132);
    public static readonly System.Drawing.Color Orange = System.Drawing.Color.FromArgb(255, 159, 64);
    public static readonly System.Drawing.Color Yellow = System.Drawing.Color.FromArgb(255, 205, 86);
    public static readonly System.Drawing.Color Green = System.Drawing.Color.FromArgb(75, 192, 192);
    public static readonly System.Drawing.Color Blue = System.Drawing.Color.FromArgb(54, 162, 235);
    public static readonly System.Drawing.Color Purple = System.Drawing.Color.FromArgb(153, 102, 255);
    public static readonly System.Drawing.Color Grey = System.Drawing.Color.FromArgb(201, 203, 207);
}

public static class BitChartDemoUtils
{
    public static readonly Random _rng = new Random();

    public static IReadOnlyList<string> Months { get; } = new ReadOnlyCollection<string>(new[]
    {
            ""January"", ""February"", ""March"", ""April"", ""May"", ""June"", ""July"", ""August"", ""September"", ""October"", ""November"", ""December""
    });

    private static int RandomScalingFactorThreadUnsafe(int min, int max) => _rng.Next(min, max);

    public static int RandomScalingFactor()
    {
        lock (_rng)
        {
            return RandomScalingFactorThreadUnsafe(0, 100);
        }
    }

    public static IEnumerable<int> RandomScalingFactor(int count, int min = 0, int max = 100)
    {
        int[] factors = new int[count];
        lock (_rng)
        {
            for (int i = 0; i < count; i++)
            {
                factors[i] = RandomScalingFactorThreadUnsafe(min, max);
            }
        }

        return factors;
    }

    public static IEnumerable<DateTime> GetNextDays(int count)
    {
        DateTime now = DateTime.Now;
        DateTime[] factors = new DateTime[count];
        for (int i = 0; i < factors.Length; i++)
        {
            factors[i] = now.AddDays(i);
        }

        return factors;
    }
}

public static class IListExtensions
{
    public static void AddRange<T>(this IList<T> list, IEnumerable<T> items)
    {
        if (list == null)
            throw new ArgumentNullException(nameof(list));

        if (items == null)
            throw new ArgumentNullException(nameof(items));

        if (list is List<T> asList)
        {
            asList.AddRange(items);
        }
        else
        {
            foreach (T item in items)
            {
                list.Add(item);
            }
        }
    }
}";
}
