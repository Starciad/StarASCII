# Contributing to the Project

We are excited to receive your contributions. However, it is crucial to follow guidelines to ensure effective collaboration.

## Versioning

We follow [Semantic Versioning (SemVer)](https://semver.org/). Prioritize PRs with `patch` or `minor` changes. Significant changes require prior discussion for integration in the next major release. Mark removals of public properties or methods as `Obsolete` in the latest release branch.

## Descriptive Titles

Use concise and descriptive titles in issues or PRs. Details should be in the description.

## Commit Messages

Follow [Conventional Commits](https://www.conventionalcommits.org/en/v1.0.0/). Each commit should describe the change. Reference open issues with `#`.

**Examples of good commit messages:**

- `fix: Fix potential memory leak (#142).`;
- `feat: Add new entity (#169).`;
- `refactor: Refactor code for the 5th entity.`;
- `feat: Add new GUI component.`.

**Examples of incorrect messages:**

- `I'm bad.`;
- `Tit and tat.`;
- `Fixed.`;
- `Oops.`.

## Code Style

We follow the [Microsoft C# coding conventions](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/inside-a-program/coding-conventions), with some exceptions.

### Main Preferences

1. Prefix `S` in file names and `IS` for interfaces;
1. Use `this` to reference fields and properties;
1. Avoid asynchronous code in inappropriate contexts.

### Other Preferences

1. Do not use `var`;
1. Mark immutable fields as `readonly`;
1. Use `internal` and `public` sparingly;
1. Utilize object initializers whenever possible.

### Inline `out` Declarations

Prefer inline form for `out` declarations: `SomeOutMethod(42, out PType value);`.

### Member Ordering

Always order members and properties: Properties, `const` Fields, Variable Fields, Events and Delegates, Constructors, Methods.

## Pull Request

When contributing and creating a PR, provide clear and informative documentation. This increases the chances of integration.

## Code Review

Each PR is carefully reviewed. If rejected, there will be justification. Thank you for dedicating time and effort to Star ASCII. Questions? Contact the team or community.
