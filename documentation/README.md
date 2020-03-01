# xTeam 2020 Sitecore Hackathon Documentation

#The documentation for this years Hackathon must be provided as a readme in Markdown format as part of your submission. 
#You can find a very good reference to Github flavoured markdown reference in [this cheatsheet](https://github.com/adam-p/markdown-here/wiki/Markdown-Cheatsheet). If you want something a bit more WYSIWYG for editing then could use [StackEdit](https://stackedit.io/app) which provides a more user friendly interface for generating the Markdown code. Those of you who are [VS Code fans](https://code.visualstudio.com/docs/languages/markdown#_markdown-preview) can edit/preview directly in that interface too.
#Examples of things to include are the following.

## Summary

**Category:** Create Sitecore Marketplace Website

Our module takes the latest Sitecore 9.3 components and directs them toward meeting the 
core needs of the Sitecore Marketplace website with miniumal overhead. Specificially,
our solution:

- Leverages SXA to construct the basic pages required for the marketplace site.
- Employs the latest SXA 9.3 components and sound helix desing patterns.
- Uses Sitecore Forms hosted in SXA to collect information about module submissions.
- Uses Sitecore remote eventing to submit modules over the network, processing them
  on remote nodes.
- Uses Sitecore templates and bucketing to manage module submission data.
- Implements Cortex tagging of submitted modules to drive search.
- Leverages SOLR and SXA search to search submitted modules.
- Uses Sitecore Data Exchange Framework to interface with GitHub and automatically
  download readmes, and other meta data for submitted code. This enables us to provide 
  a rich user experience in the marketplace while leaving much of the work of package 
  management to third party specialists.
- Returns relvant search results for submitted modules with faceting.
- Adorns search results with relevant data about submissions retrieved automatically
  from GitHub.

## Pre-requisites

Our module has the following requirements:
- Sitecore 9.3 installed with SXA.
- Sitecore Data Excahnge Framework.
- Installation of the provided Sitecore content package.
- Installation of the source code included in this solution.

## Installation

Provide detailed instructions on how to install the module, and include screenshots where necessary.

1. Install Sitecore 9.3 using the graphical installer, checking the option to install SXA.
2. Install the Sitecore 9.3 Data Exchange Framework from the Sitecore installation package at:
    https://dev.sitecore.net/Downloads/Data_Exchange_Framework/4x/Data_Exchange_Framework_400.aspx
3. Install the Sitecore installation package included at:
    [Path to our Sitecore package.]
    This will install the Sitecore resources and the DLLs for our project.

## Configuration

You should not need 

## Usage

There is already substantial content and marketing assets attached to the Marketplace website that can
be reasonably reused in any web redesign. Rather than focusing on what would amount to a proposal for a 
site design, this solution demonstrates how in a very short time, several technical needs of the marketplace
website simply by integrating OOTB Sitecore components with some minor integration efforts.

We have two primary classes of users for our solution:
- Contributors submitting Sitecore modules for consumption by the community.
- Consumers coming to the marketplace seeking Sitecore components.

Contributors will visit the the contribute form where they can input their module information along with 
URLs for GitHub and their documentation. We will gather additional meta data from GitHub for display with
search results.

Consumers are primarily interested in searching for packages. We use Cortex tagging and SXA search to
provide search accross the installed modules. We use Sitecore Data Exchange Framework to call out to 
GitHub and retrieve addtional meta information on the search packages to enhance the user experience.

## Video

Please provide a video highlighing your Hackathon module submission and provide a link to the video. Either a [direct link](https://www.youtube.com/watch?v=EpNhxW4pNKk) to the video, upload it to this documentation folder or maybe upload it to Youtube...

[![Sitecore Hackathon Video Embedding Alt Text](https://img.youtube.com/vi/EpNhxW4pNKk/0.jpg)](https://www.youtube.com/watch?v=EpNhxW4pNKk)
