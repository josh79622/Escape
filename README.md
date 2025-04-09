# 🎮 Escape - 3D Animation Assignment

This is a Unity 6 project for our 3D Animation course.  
We are using Git LFS to manage large assets such as textures, models, and environment files (e.g., Horror_Mansion).  
Please follow the setup steps below to ensure everything works correctly.

---

## 🧰 Requirements

- Unity 6
- Git
- Git LFS (Large File Storage)

---

## 🔁 First-time Setup

### 💻 Clone the repository

Make sure you clone the `develop` branch instead of `main`:

```bash
git clone -b develop https://github.com/josh79622/Escape.git
cd Escape
```

### 💡 Install Git LFS (Only Once)

#### On macOS:

```bash
brew install git-lfs
```

#### On Windows:

1. Download Git LFS from: https://git-lfs.github.com/
2. Install it, then open Git Bash and run:

```bash
git lfs install
```

---

### 📥 Pull LFS files

After cloning the repo, you **must** pull the actual large asset files:

```bash
git lfs pull
```

Without this step, large Unity assets like `Horror_Mansion` will not work correctly in your Unity editor.

---

## 🚧 Development Guidelines

🚨 **DO NOT commit or push directly to the `main` branch.**

We use the `main` branch as the **production** branch, and only allow merges from `develop` via pull request.

### Development Flow

1. Pull the latest changes from `develop`:

   ```bash
   git pull origin develop
   ```

2. Create a new feature branch from `develop`:

   ```bash
   git checkout -b feature/your-feature-name
   ```

3. Make changes, then commit and push:

   ```bash
   git add .
   git commit -m "Describe your changes"
   git push origin feature/your-feature-name
   ```

4. Open a **pull request to `develop`** on GitHub.

---

## 🏗️ Scene Setup

Please use the following scene for development:

```text
Assets/Scenes/Horror Mansion.unity
```

Open this scene in Unity and continue building from there.

---

## ❓Troubleshooting

If Unity fails to open files, or if you see `.gitattributes`-like placeholder files:

```bash
git lfs pull
```

Also verify that Git LFS is correctly installed and initialized on your system.

---

## 🙌 Contributors

- Josh Tsai
- [Add team member names here]

---