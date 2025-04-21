# SoftSketch

This repo is for the HKU COMP7506 Smartphone Apps Development Group Project, which is a game demo using Soft2D plugin developed by [taichi-dev](https://github.com/taichi-dev) to simulate the motion of fluids in 2D space. This project supports building and running on **Windows, Linux, Mac, Android, and iOS** platforms.


## Environment Requirements

| Unity Version | Graphics API    | Rendering Pipeline | Scripting Backend |
| ------------- | --------------- | ------------------ | ----------------- |
| 2021.3.22f1c1 | Vulkan or Metal | Built-in or URP    | IL2CPP            |

> Note: MacOS currently only supports M1 chips.


## How to clone

You can download this repository and open it as a new project in Unity. Remember to use **git-lfs** to correctly pull the Soft2D's binary files in the project:

```
git clone https://github.com/Karm0tr1ne/SoftSketch.git
cd your/path/SoftSketch/
git lfs pull
```


## How to build

- Open `File > Build Settings` Window in the upper left corner of the Unity editor
- Choose the `Platform` you need and press `Build` button


## References

- [Soft2D](https://github.com/taichi-dev/soft2d-release)
