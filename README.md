# Meal Recipes

Meal-Recipes
Meal-Recipes is an interactive and visually engaging Blazor Server web application that brings the joy of international cuisine to your kitchen. The platform offers a rich collection of meal recipes from around the world, complete with ingredients, step-by-step instructions (recettes), and video tutorials to help users enjoy an enjoyable and fantastic cooking experience.

Key Features:
🌍 Global Variety of Meals
Explore traditional and modern recipes from diverse countries and cultures.

🍽️ Complete Recipe Details
Each recipe includes ingredients, preparation steps, and an optional video walkthrough.

📈 User Insights Dashboard
A real-time dashboard using Google Charts displays analytics on user behavior, such as:

Most viewed recipes

Popular cuisines by country

Cooking trends over time

🎥 Video Tutorials
Embedded videos guide users through the recipe visually and interactively.

Tech Stack & Architecture:
Blazor Server

Utilizes the latest Stream Rendering mode for enhanced performance and interactivity

Employs Server Interactivity for seamless and reactive user experiences

Google Charts Integration

For dynamic, real-time visualization of recipe popularity and user preferences

Azure Serverless (Event-Driven Architecture)

Recipe views are logged using Azure Functions

Events are sent asynchronously to enable real-time tracking without affecting user experience

Event data stored in a scalable backend (e.g., Azure Table Storage or Cosmos DB)

Dependency Injection (DI)

All services are designed to be testable and loosely coupled using ASP.NET Core DI

Architecture Highlights:
Event Logging Flow:

User views a recipe

Blazor triggers an event to an Azure Function

Function logs the view occurrence

Dashboard updates aggregated stats via scheduled or real-time updates

Modular Component Design:
Recipes, filters, video player, and dashboard are all reusable Blazor components
