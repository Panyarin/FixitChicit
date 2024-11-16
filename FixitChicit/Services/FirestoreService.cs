using System;
using FixitChicit.MVVM.Models;
using Google.Cloud.Firestore;

namespace FixitChicit.Services;

public class FirestoreService
{
    private FirestoreDb db;
    public string StatusMessage;

    public FirestoreService()
    {
        this.SetupFireStore();
    }
    private async Task SetupFireStore()
    {
        if (db == null)
        {
            var stream = await FileSystem.OpenAppPackageFileAsync("fixitchicit-158ee-firebase-adminsdk-td6m3-0b69ab8826.json");
            var reader = new StreamReader(stream);
            var contents = reader.ReadToEnd();
            db = new FirestoreDbBuilder
            {
                ProjectId = "fixitchicit-158ee",

                JsonCredentials = contents
            }.Build();
        }
    }
     public async Task<List<DetailShirt>> GetAllDetailShirt()
    {
        try
        {
            await SetupFireStore();
            var data = await db.Collection("DetailShirt").GetSnapshotAsync();
            var detailShirts = data.Documents.Select(doc =>
            {
                var detailShirt = new DetailShirt();
                detailShirt.Id = doc.Id;
                detailShirt.Name = doc.GetValue<string>("Name");
                detailShirt.Phone= doc.GetValue<string>("Phone");
                detailShirt.Address = doc.GetValue<string>("Address");
                detailShirt.Type= doc.GetValue<string>("Type");
                detailShirt.Problem = doc.GetValue<string>("Problem");
                return detailShirt;
            }).ToList();
            return detailShirts;
        }
        catch (Exception ex)
        {

            StatusMessage = $"Error: {ex.Message}";
        }
        return null;
    }
    public async Task InsertDetailShirt(DetailShirt detailShirt)
    {
        try
        {
            await SetupFireStore();
            var detailShirtData = new Dictionary<string, object>
            {
                { "Name", detailShirt.Name },
                { "Phone", detailShirt.Phone },
                { "Address", detailShirt.Address },
                { "Type", detailShirt.Type },
                { "Problem", detailShirt.Problem}
                // Add more fields as needed
            };

            await db.Collection("DetailShirt").AddAsync(detailShirtData);
        }
        catch (Exception ex)
        {

            StatusMessage = $"Error: {ex.Message}";
        }
    }
    public async Task UpdateDetailShirt(DetailShirt detailShirt)
    {
        try
        {
            await SetupFireStore();

            // Manually create a dictionary for the updated data
            var detailShirtData = new Dictionary<string, object>
            {
                { "Name", detailShirt.Name },
                { "Phone", detailShirt.Phone },
                { "Address", detailShirt.Address },
                { "Type", detailShirt.Type },
                { "Problem", detailShirt.Problem}
                // Add more fields as needed
            };

            // Reference the document by its Id and update it
            var docRef = db.Collection("Detailshirt").Document(detailShirt.Id);
            await docRef.SetAsync(detailShirtData, SetOptions.Overwrite);

            StatusMessage = "Sample successfully updated!";
        }
        catch (Exception ex)
        {
            StatusMessage = $"Error: {ex.Message}";
        }
    }
    public async Task DeleteDetailShirt(string id)
    {
        try
        {
            await SetupFireStore();

            // Reference the document by its Id and delete it
            var docRef = db.Collection("DetailShirts").Document(id);
            await docRef.DeleteAsync();

            StatusMessage = "Sample successfully deleted!";
        }
        catch (Exception ex)
        {
            StatusMessage = $"Error: {ex.Message}";
        }
    }




    //Skirt
        public async Task<List<DetailSkirt>> GetAllDetailSkirt()
    {
        try
        {
            await SetupFireStore();
            var data = await db.Collection("DetailSkirt").GetSnapshotAsync();
            var detailSkirts = data.Documents.Select(doc =>
            {
                var detailSkirt = new DetailSkirt();
                detailSkirt.Id = doc.Id;
                detailSkirt.Name = doc.GetValue<string>("Name");
                detailSkirt.Phone= doc.GetValue<string>("Phone");
                detailSkirt.Address = doc.GetValue<string>("Address");
                detailSkirt.Type= doc.GetValue<string>("Type");
                detailSkirt.Problem = doc.GetValue<string>("Problem");
                return detailSkirt;
            }).ToList();
            return detailSkirts;
        }
        catch (Exception ex)
        {

            StatusMessage = $"Error: {ex.Message}";
        }
        return null;
    }
    public async Task InsertDetailSkirt(DetailSkirt detailSkirt)
    {
        try
        {
            await SetupFireStore();
            var detailSkirtData = new Dictionary<string, object>
            {
                { "Name", detailSkirt.Name },
                { "Phone", detailSkirt.Phone },
                { "Address", detailSkirt.Address },
                { "Type", detailSkirt.Type },
                { "Problem", detailSkirt.Problem}
                // Add more fields as needed
            };

            await db.Collection("DetailSkirt").AddAsync(detailSkirtData);
        }
        catch (Exception ex)
        {

            StatusMessage = $"Error: {ex.Message}";
        }
    }
    public async Task UpdateDetailSkirt(DetailSkirt detailSkirt)
    {
        try
        {
            await SetupFireStore();

            // Manually create a dictionary for the updated data
            var detailSkirtData = new Dictionary<string, object>
            {
                { "Name", detailSkirt.Name },
                { "Phone", detailSkirt.Phone },
                { "Address", detailSkirt.Address },
                { "Type", detailSkirt.Type },
                { "Problem", detailSkirt.Problem}
                // Add more fields as needed
            };

            // Reference the document by its Id and update it
            var docRef = db.Collection("Detailskirt").Document(detailSkirt.Id);
            await docRef.SetAsync(detailSkirtData, SetOptions.Overwrite);

            StatusMessage = "Sample successfully updated!";
        }
        catch (Exception ex)
        {
            StatusMessage = $"Error: {ex.Message}";
        }
    }
    public async Task DeleteDetailSkirt(string id)
    {
        try
        {
            await SetupFireStore();

            // Reference the document by its Id and delete it
            var docRef = db.Collection("DetailSkirts").Document(id);
            await docRef.DeleteAsync();

            StatusMessage = "Sample successfully deleted!";
        }
        catch (Exception ex)
        {
            StatusMessage = $"Error: {ex.Message}";
        }
    }

}



