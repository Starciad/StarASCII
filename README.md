# StarASCII

[![MIT License](https://img.shields.io/badge/license-MIT-blue.svg?style=flat-square)](./LICENSE)
[![NuGet](https://img.shields.io/nuget/v/StarASCII.svg?label=NuGet)](https://www.nuget.org/packages/StarASCII/)

🧩 ➥ Library for creating ASCII animations for terminals.

## Table of Contents

- [Installation](#installation)
- [Getting Started](#getting-started)
- [Contributing](#contributing)
- [License](#license)

## Installation

The latest version is available on [NuGet](https://www.nuget.org/packages/StarASCII/). To install, run:

```bash
dotnet add package StarASCII --version *
```

> Replace the asterisk (*) with the desired version.

Alternatively, clone the repository and reference it manually:

```bash
git clone https://github.com/Starciad/StarASCII.git
```

## Getting Started

After installation, add the `StarASCII` namespace:

```cs
using StarASCII;
```

You can now use the `SAnimation` class to create and run animations:

```cs
SAnimation anim = new SAnimation();
```

Next, add frames using the `AddFrame(SFrame)` method:

```cs
SFrame frame = new SFrame(string, uint);
anim.AddFrame(frame);
```

- `string`: content of the frame.
- `uint`: duration in milliseconds.

Once all frames are added, run the animation:

```cs
anim.Play();
```

> [!IMPORTANT]
> When calling `Play()`, the main thread will be paused according to the frame durations.

Explore the classes and features to fully customize your animations.

### Tips and Recommendations

1. **Frame size:** Keep all frames the same size to avoid visual issues.
2. **Using text files:** For complex animations, save frames in external text files or use `const` or `readonly static` properties to avoid hardcoded ASCII art.
3. **Reuse animations:** To save resources, reuse animations by storing them in collections, lists, or static properties, especially in performance-critical scenarios like loops.

## Samples

Try the sample project [here](./src/StarASCII.Samples/). You can also view some GIFs showcasing the library's capabilities:

- Sample 1: Blinking Eye ![sample_01]
- Sample 2: Walking Man ![sample_02]
- Sample 3: Zebra ![sample_03]

## Issues

Have a problem? Open an issue!

## Contributing

Contributions are welcome! Please check the [CONTRIBUTING.md](./.github/CONTRIBUTING.md) for guidelines.

## License

This project is licensed under the MIT License. See the [LICENSE.md](./LICENSE) file for details.

<!-- IMAGES -->
[sample_01]: ./.github/assets/graphics/samples/sample_01.webp
[sample_02]: ./.github/assets/graphics/samples/sample_02.webp
[sample_03]: ./.github/assets/graphics/samples/sample_03.webp
