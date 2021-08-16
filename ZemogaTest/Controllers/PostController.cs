﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZemogaTest.Services.Dtos;
using ZemogaTest.Services.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ZemogaTest.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private IPostService _postService;

        public PostController(IPostService postService)
        {
            _postService = postService;
        }

        // GET: api/<PostController>
        [HttpGet]
        public async Task<ActionResult<ApiResponse>> Get()
        {
            var result = _postService.GetAllPosts();
            return Ok(result);
        }

        // GET api/<PostController>/5
        [HttpGet("{postId}")]
        public async Task<ActionResult<ApiResponse>> Get(Guid postId)
        {
            var result = _postService.GetPost(postId);
            return Ok(result);
        }

        // POST api/<PostController>
        [HttpPost]
        [Route("CreatePost")]
        public async Task<ActionResult<ApiResponse>> CreatePost([FromBody] CreatePostRequest request)
        {
            var result = _postService.CreatePost(request);
            return Ok(result);
        }

        // POST api/<PostController>
        [HttpPost]
        [Route("AddComment")]
        public async Task<ActionResult<ApiResponse>> AddComment([FromBody] string value)
        {
            return Ok();
        }

        // PUT api/<PostController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<ApiResponse>> Put(int id, [FromBody] string value)
        {
            return Ok();
        }
    }
}