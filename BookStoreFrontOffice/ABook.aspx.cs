﻿using System;
using BookStoreClasses;



public partial class ABook : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //if this is the first time the page is displayed
        if (IsPostBack == false)
        {
            //update the list box
            DisplayBooks();
        }

    }

    void DisplayBooks()
    {
        //create an instance of the ??? Collection * simplified code *
        clsBookCollection Books = new clsBookCollection();
        //set the data source to the list of ??? on the collection
        lstBooks.DataSource = Books.BookList;
        //set the name of the primary key
        lstBooks.DataValueField = "BookId";
        //set the data field to display
        lstBooks.DataTextField = "BookTitle";
        //bind the data to the list
        lstBooks.DataBind();
    }

    protected void btnOK_Click(object sender, EventArgs e)
    {
        
        //create a new instance of the class
        clsBook ABook = new clsBook();
        //capture the author
        string Author = txtAuthor.Text;
        //capture the title
        string BookTitle = txtTitle.Text;
        //capture the author
        string PublicationYear = txtPubYear.Text;
        //capture the author
        string Edition = txtEdition.Text;
        //capture the author
        string Price = txtPrice.Text;
        //capture the author
        string BookShelfNo = txtShelfNo.Text;

        string Error = "";
        Error = ABook.Valid(Author, BookTitle, PublicationYear, Edition, Price, BookShelfNo);
        if (Error == "")
        {
            //capture the author
            ABook.Author = Author;
            //capture the title
            ABook.BookTitle = BookTitle;
            //capture the PubYear
            ABook.PublicationYear = int.Parse(PublicationYear);
            //capture the book shelf no
            ABook.BookShelfNo = decimal.Parse(BookShelfNo);
            //capture the price
            ABook.BookPrice = decimal.Parse(Price);
            //capture the edition
            ABook.Edition = int.Parse(Edition);
            //store the author in the session object
            Session["ABook"] = ABook;
            //redirect to the page
            Response.Redirect("BookViewer.aspx");
        }
        else
        {
            //display the error msg
            lblError.Text = Error;
        }
        
    }

    protected void btnFind_Click(object sender, EventArgs e)
    {
        clsBook ABook = new clsBook();
        int BookId;
        Boolean Found = false;
        BookId = Convert.ToInt32(txtBookId.Text);
        Found = ABook.Find(BookId);
        if (Found == true)   
        {
            txtAuthor.Text = ABook.Author;
            txtTitle.Text = ABook.BookTitle;
            txtPubYear.Text = ABook.PublicationYear.ToString();
            txtEdition.Text = ABook.Edition.ToString();
            txtShelfNo.Text = ABook.BookShelfNo.ToString();
            txtPrice.Text = ABook.BookPrice.ToString();
            ddlGenre.Text = ABook.GenreName;

        }
    }
}