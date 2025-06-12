# NuGet Package Template
> This repository is a template for **Public .NET Libraries** that will be published as **NuGet Packages**.

[![tests](https://github.com/TJC-Templates/Template.NuGet.Package/actions/workflows/ct-matrix.yml/badge.svg)](https://github.com/TJC-Templates/Template.NuGet.Package/actions/workflows/ct-matrix.yml)

## Table of Contents
- [Setup](#setup)
- [TJC.Replace](#tjcreplace)

---
## Setup
> Note: Ensure the **Repository** name, **NuGet Package** name & folder/name of the main `.csproj` are ***all*** the same.
>
> This is requried because [some automation](.github/workflows/tag-creates-nuget-package.yml) uses `${{ github.repository }}` in place of the **folder**/**name** of the `.csproj` (to make the workflow more easily reusable between repositories).

1. Clone the repository
2. Rename `TJC.Rename` & `TJC.Rename.Tests` folders & `.csproj` files to the desired library name (ensure it matches the **repository name**)
    1. Update the following `.csproj` file properties
        1. `Title`
        2. `Description`
        3. `RepositoryUrl`
        4. `InternalsVisibleToAttribute`
3. ~~In `workflows` replace the `{REPLACE_ME}` placeholders~~
4. Setup [codecov](https://app.codecov.io/gh/TJC-Tools) for *this* repository
5. In the `README.md` delete everything above [TJC.Replace](#tjcreplace) & add some *initial* **documentation**
   1. Replace all `TJC.Replace` with the name of the new **repository**
        1. Replace `REPLACE_CODECOV_TOKEN` with a token once [codecov](https://app.codecov.io/gh/TJC-Tools) is setup
6. Delete the [ruleset](.github/ruleset.json) (back it up somewhere locally for later)
7. Amend the initial commit & force push the changes using `git push -f`
8. ~~Set `GitHub NuGet Package` visibility to `public`~~
9. **Repository Settings**
   1. Import repository permissions from the local backup of [ruleset](.github/ruleset.json)
   2. **Pull Requests**
        1. Disable `Allow merge commits`
        2. Enable `Always suggest updating pull request branches`
        3. Enable `Automatically delete head branches`
10. On **GitHub** deselect **Packages** & **Deployments**
11. On **GitHub** add a **Description**, **Website** link to [www.nuget.org/packages/TJC.Replace](https://www.nuget.org/packages/TJC.Replace) & **Topics**
12. Create first branch with intial code & create a **pull request** with a `minor` tag to create the first **release**

---
# TJC.Replace

![GitHub Tag](https://img.shields.io/github/v/tag/TJC-Tools/TJC.Replace)
[![GitHub Release](https://img.shields.io/github/v/release/TJC-Tools/TJC.Replace)](https://github.com/TJC-Tools/TJC.Replace/releases/latest)
[![NuGet Version](https://img.shields.io/nuget/v/TJC.Replace)](https://www.nuget.org/packages/TJC.Replace)

[![NuGet Downloads](https://img.shields.io/nuget/dt/TJC.Replace)](https://www.nuget.org/packages/TJC.Replace)
![Size](https://img.shields.io/github/repo-size/TJC-Tools/TJC.Replace)
[![License](https://img.shields.io/github/license/TJC-Tools/TJC.Replace.svg)](LICENSE)

[![tests](https://github.com/TJC-Tools/TJC.Replace/actions/workflows/ct-matrix.yml/badge.svg)](https://github.com/TJC-Tools/TJC.Replace/actions/workflows/ct-matrix.yml)
[![codecov](https://codecov.io/gh/TJC-Tools/TJC.Replace/graph/badge.svg?token=REPLACE_CODECOV_TOKEN)](https://codecov.io/gh/TJC-Tools/TJC.Replace)

## Documentation
- [Changelog](CHANGELOG.md)
