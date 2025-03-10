# 🎬 Movie API

## 📖 Overview
This is a **Movie API** built with **.NET 8, Entity Framework Core, and SQLite**.  
It allows users to **search, filter, and paginate movies** based on various criteria such as **title, genre, actor (from overview), and sort on title or release date**.

---

### Available Filters
- **Title**: Search movies by title. Example: `?Title=Inception`
- **Genre**: Filter movies by genre. Example: `?Genre=Action`
- **Actor**: Search movies by actor (from the overview). Example: `?Actor=Leonardo%20DiCaprio`
- **Sort By**: Sort the results by a specific field. Example: `?SortBy=title` or `?SortBy=release_date`
