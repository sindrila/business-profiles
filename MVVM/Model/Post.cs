﻿using System;
public class Post
{
    private int _id;
    private int _businessId;
    private int _numberOfLikes;
    private DateTime _creationDate;
    private string _imagePath;
    private string _caption;
    private List<Comment> _comments;

    public int Id => _id;
    public int BusinessId => _businessId;
    public int NumberOfLikes => _numberOfLikes;
    public DateTime CreationDate => _creationDate;
    public string ImagePath => _imagePath;
    public string Caption => _caption;
    public List<Comment> Comments => _comments;

    public Post(int id, int businessId, DateTime creationDate, string imagePath, string caption)

    {
        _id = id;
        _businessId = businessId;
        _numberOfLikes = 0;
        _creationDate = creationDate;
        _imagePath = imagePath;
        _caption = caption;
        _comments = new List<Comment>();
    }

    public void SetNumberOfLikes(int likes) => _numberOfLikes = likes;
    public void SetCreationDate(DateTime creationDate) => _creationDate = creationDate;
    public void SetImagePath(string imagePath) => _imagePath = imagePath;
    public void SetCaption(string caption) => _caption = caption;
    //public void SetProduct(Product product) => _product = product;

    public void AddLike() { _numberOfLikes++; }
    public void AddComment(Comment comment) { _comments.Add(comment); }

}