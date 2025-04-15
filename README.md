# 🎮 Escape - 3D Animation Assignment

This is a Unity project for our 3D Animation course.  
We are using Git LFS to manage large assets such as textures, models, and environment files (e.g., Horror_Mansion).  
Please follow the setup steps below to ensure everything works correctly.

---

## 🧰 Requirements

- Unity **6000.0.45f1**
- Git
- Git LFS (Large File Storage)

---

## 🔁 First-time Setup

### 💻 Clone the repository and switch to the develop branch

```bash
git clone https://github.com/josh79622/Escape.git
cd Escape
git checkout develop
git pull origin develop
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

🚨 **DO NOT commit or push directly to the `main` or `develop` branches.**  
Create your own feature branch to work from.

---

### 🛠 Recommended Workflow

1. Make sure you're on the latest `develop`:

```bash
git checkout develop
git pull origin develop
```

2. Create a new personal feature branch (e.g., `josh/sprint1`):

```bash
git checkout -b josh/sprint1
```

3. Make changes in Unity

4. Stage and commit your changes:

```bash
git add .
git commit -m "Describe what you did here"
```

5. Push your feature branch to GitHub:

```bash
git push -u origin josh/sprint1
```

6. Open a **Pull Request** on GitHub to merge your branch into `develop`.

---

## 🏗️ Scene Setup

Please use the following scene for development:

```text
Assets > Scenes > Intro.unity
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

## 🔐 How to Generate a GitHub Token (For Push Access)

GitHub no longer allows password authentication when pushing from the terminal. Instead, use a **Personal Access Token (PAT)**.

Follow these steps:

### ✅ Step 1: Create your token

1. Go to: [https://github.com/settings/tokens](https://github.com/settings/tokens)
2. Click **"Fine-grained tokens"** or **"Classic tokens"**
3. Click **"Generate new token"**
4. Set:
   - **Name**: e.g. `Escape Project Token`
   - **Expiration**: 30 days, 60 days, or No expiration
   - **Permissions**:
     - ✅ `repo` (for full access to repositories)
     - Optional: `workflow` if you use GitHub Actions
5. Click **Generate token**
6. 🔐 **Copy the token and store it safely** – You won't see it again!

### ✅ Step 2: Set the token in your terminal

When you do this for the first time:

```bash
git push
```

Git will ask for:

- **Username** → enter your GitHub username  
- **Password** → paste the **token** (not your password)

💡 To save the token, you can use a credential helper:

#### macOS:
```bash
git config --global credential.helper osxkeychain
```

#### Windows:
```bash
git config --global credential.helper wincred
```

From now on, Git will remember your token securely and let you push without reentering it.